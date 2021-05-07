using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.Entidades
{
    [Table("CITA")]
    public class Cita
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Column("ID")]
        public long id { get; set; }
        [Required]
        [Column("FECHAHORA")]
        public DateTime? fechaHora { get; set; }
        [Required]
        [Column("MOTIVO")]
        public String motivo { get; set; }
        [Required]
        [Column("PACIENTE")]
        public long pacienteId { get; set; }
        public virtual Paciente paciente {get; set;}
        [Required]
        [Column("MEDICO")]
        public long medicoId { get; set; }
        public virtual Medico medico {get; set;}
        public virtual Diagnostico diagnostico {get; set;}

    }
}