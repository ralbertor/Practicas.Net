using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Catalog.DTOs.CitaDTO;
using Catalog.Entidades;
using Catalog.Services;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("citas")]
    public class CitaController : ControllerBase
    {
        private readonly CitaService citaService;

        private readonly IMapper mapper;
        public CitaController(CitaService citaService, IMapper mapper)
        {
            this.citaService = citaService;
            this.mapper = mapper;
        }

        // GET /citas
        [HttpGet]
        public async Task<IEnumerable<CitaDTO>> GetCitas()
        {
            ICollection<Cita> citas = await citaService.findAllAsync();
            return mapper.Map<ICollection<Cita>, ICollection<CitaDTO>>(citas);
        }

        // Get /citas/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CitaDTO>> GetCita(long id)
        {
            Cita cita = await citaService.findByIdAsync(id);
            if (cita is null)
            {
                return NotFound();
            }
            return mapper.Map<Cita, CitaDTO>(cita);
        }

        // Post /citas/add
        [HttpPost("add")]
        public async Task<ActionResult<CitaDTO>> CreateCita(CreateCitaDTO citaDto)
        {
            Cita cita = mapper.Map<CreateCitaDTO, Cita>(citaDto);
            var newCitaId = await citaService.saveAsync(cita);
            if (newCitaId == null)
                return BadRequest();
            return await GetCita((long)newCitaId);
        }

        // PUT /citas/update
        [HttpPut("update")]
        public async Task<ActionResult<CitaDTO>> UpdateCita(CitaDTO citaDto)
        {
            Cita cita = mapper.Map<CitaDTO, Cita>(citaDto);
            var updated = await citaService.updateAsync(cita);
            if (!updated)
                return NotFound();
            return await GetCita(cita.id);
        }
        
        // DELETE /citas/delete/{id}
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteCita(long id)
        {
            if (await citaService.deleteAsync(id))
                return NoContent();
            return NotFound();
        }
    }
}