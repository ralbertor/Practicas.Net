using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.Entidades
{
    [Table("USUARIO")]
    public abstract class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Column("id")]
        public long id { get; set; }
        [Required]
        [Column("usuario")]
        public String usuario { get; set; }
        [Required]
        [Column("clave")]
        public String clave { get; set; }
        [Required]
        [Column("nombre")]
        public String nombre { get; set; }
        [Required]
        [Column("apellidos")]
        public String apellidos { get; set; }

    }
}