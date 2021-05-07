using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.Entidades
{
    [Table("DIAGNOSTICO")]
    public class Diagnostico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int id { get; set; }
        [Required]
        [Column("ENFERMEDAD")]
        public String enfermedad { get; set; }
        [Required]
        [Column("VALORACION")]
        public String valoracionEspecialista { get; set; }
        [Required]
        [Column("CITA")]
        public long citaId;
        public virtual Cita cita { get; set; }

    }
}