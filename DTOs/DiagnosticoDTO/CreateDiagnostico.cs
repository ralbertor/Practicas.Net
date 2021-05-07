using System.ComponentModel.DataAnnotations;

namespace Catalog.DTOs.DiagnosticoDTO
{
    public class CreateDiagnosticoDTO
    {
        [Required]
        public string valoracionEspecialista { get; set; }
        [Required]
        public string enfermedad { get; set; }
        [Required]
        public CitaDTO cita { get; set; }
    }
}