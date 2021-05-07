using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.Entidades
{
    [Table("MEDICO_PACIENTE")]
    public class MedicoPaciente{
        [Required]
        [Column("MEDICO")]
        public long medicoId{get; set;}
        public virtual Medico medico{get; set;}
        [Required]
        [Column("PACIENTE")]
        public long pacienteId{get; set;}
        public virtual Paciente paciente {get; set;}

    }
}