using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Catalog.DTOs.MedicoDTO;
using Catalog.DTOs.RegisterDTO;
using Catalog.Entidades;
using Catalog.Services;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("medicos")]
    public class MedicoController : ControllerBase
    {
        private readonly MedicoService medService;
        private readonly IMapper mapper;
        public MedicoController(MedicoService medService, IMapper mapper)
        {
            this.medService = medService;
            this.mapper = mapper;
        }

        // GET /medicos
        [HttpGet]
        public async Task<IEnumerable<MedicoDTO>> GetMedicos()
        {
            ICollection<Medico> meds = await medService.findAllAsync();
            return mapper.Map<ICollection<Medico>, ICollection<MedicoDTO>>(meds);
        }

        // Get /medicos/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<MedicoDTO>> GetMedico(long id)
        {
            Medico med = await medService.findByIdAsync(id);
            if (med is null)
            {
                return NotFound();
            }
            return mapper.Map<Medico, MedicoDTO>(med);
        }

        // Post /medicos/add
        [HttpPost("add")]
        public async Task<ActionResult<MedicoDTO>> CreateMedico(MedicoRegistroDTO medRegDto)
        {
            Medico med = mapper.Map<MedicoRegistroDTO, Medico>(medRegDto);
            var newId = await medService.saveAsync(med);
            if (newId == null)
                return BadRequest();
            return await GetMedico((long)newId);
        }

        // PUT /medicos/update
        [HttpPut("update")]
        public async Task<ActionResult<MedicoDTO>> UpdateMedico(MedicoDTO medDto)
        {
            Medico med = mapper.Map<MedicoDTO, Medico>(medDto);
            var updated = await medService.updateAsync(med);
            if (!updated)
                return NotFound();
            return await GetMedico(med.id);
        }
        
        // DELETE /medicos/delete/{id}
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteMedico(long id)
        {
            if (await medService.deleteAsync(id))
                return NoContent();
            return NotFound();
        }
    }
}