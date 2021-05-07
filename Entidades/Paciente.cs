using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.Entidades
{
    [Table("PACIENTE")]
    public class Paciente :Usuario
    {
        [Required]
        [Column("NSS")]
        public String Nss { get; set; }
        [Required]
        [Column("NUMTARJETA")]
        public String numTarjeta { get; set; }
        [Required]
        [Column("TELEFONO")]
        public String telefono { get; set; }
        [Required]
        [Column("DIRECCION")]
        public String direccion { get; set; }
        public ICollection<Cita> citas { get; set; }
        public ICollection<MedicoPaciente> medicos { get; set; }

         public void addCita(Cita c)
        {
            citas.Add(c);
        }
        public bool removeCita(Cita c)
        {
            return citas.Remove(c);
        }
        public void addMedico(Medico m)
        {
            medicos.Add(new MedicoPaciente{paciente = this, medico = m});
        }
        public bool removeMedico(Medico m)
        {
            return medicos.Remove(new MedicoPaciente{paciente = this, medico = m});
        }
    }
}