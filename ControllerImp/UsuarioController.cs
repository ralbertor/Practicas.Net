using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Catalog.DTOs;
using Catalog.DTOs.MedicoDTO;
using Catalog.DTOs.PacienteDTO;
using Catalog.Entidades;
using Catalog.Services;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService service;
        private readonly IMapper mapper;
        public UsuarioController(UsuarioService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpPost("usuarios/usuarioExists")]
        public async Task<string> CheckIfUsuarioExists()
        {
            // Request is only a string in text/plain, can't use json
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8)) {
                string usuario = await reader.ReadToEndAsync();
                Usuario user = await service.findByUsuarioAsync(usuario);
                if (user == null)
                    return "false";
                return "true";
            }
        }

        [HttpPost("auth")]
        public async Task<dynamic> Login(LoginDTO login)
        {
            Usuario user = await service.findByUsuarioAsync(login.usuario);
            if (user == null) {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status401Unauthorized, "La combinación de usuario y contraseña es incorrecta");
            }
            if (!user.clave.Equals(login.clave)) {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status401Unauthorized, "La combinación de usuario y contraseña es incorrecta");
            }
            if (user is Medico) {
                return Ok(mapper.Map<Medico, MedicoDTO>((Medico) user));
            } else {
                return Ok(mapper.Map<Paciente, PacienteDTO>((Paciente) user));
            }
        }
    }
}