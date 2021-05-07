using System;

namespace Catalog.DTOs.CitaDTO
{
    public class CitaDTO{
        public long id {get; set;}
        public DateTime? fechaHora {get;set;}
        public String motivo { get; set; }
        public PacienteOnlyDTO paciente { get; set; }
        public MedicoOnlyDTO medico {get; set;}
        public DiagnosticoOnlyDTO diagnostico{get;set;}
        
    }
}