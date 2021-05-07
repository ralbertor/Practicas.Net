using System.ComponentModel.DataAnnotations;

namespace Catalog.DTOs.RegisterDTO
{
    public class MedicoRegistroDTO
    {
        [Required]
        public string usuario { get; set; }
        [Required]
        public string clave { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string apellidos { get; set; }
        [Required]
        public string numColegiado { get; set; }
    }
}