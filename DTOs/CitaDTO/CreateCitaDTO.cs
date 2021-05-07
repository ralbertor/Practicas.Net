using System;
using System.ComponentModel.DataAnnotations;

namespace Catalog.DTOs.CitaDTO
{
    public class CreateCitaDTO{
        [Required]
        public DateTime? fechaHora{get;set;}
        [Required]
        public string motivo{get;set;}
        [Required]
        public PacienteOnlyDTO paciente{get;set;}
        [Required]
        public MedicoOnlyDTO medico{get;set;}
        
    }
}