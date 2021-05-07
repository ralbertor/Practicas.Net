using System;
using System.Runtime.Serialization;

namespace Catalog.DTOs.DiagnosticoDTO
{
    public class CitaDTO
    {
        public long id { get; set; }
        public DateTime fechaHora { get; set; }
        public string motivoCita { get; set; }
        public PacienteOnlyDTO paciente { get; set; }
        public MedicoOnlyDTO medico { get; set; }
    }
}