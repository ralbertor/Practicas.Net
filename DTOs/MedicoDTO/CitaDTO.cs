using System;

namespace Catalog.DTOs.MedicoDTO
{
    public class CitaDTO
    {
        public long id { get; set; }
        public DateTime fechaHora { get; set; }
        public string motivoCita { get; set; }
        public PacienteOnlyDTO paciente { get; set; }
        public DiagnosticoOnlyDTO diagnostico { get; set; }
    }
}