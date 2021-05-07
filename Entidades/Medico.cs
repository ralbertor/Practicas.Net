using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.Entidades
{
    [Table("MEDICO")]
    public class Medico : Usuario
    {
        [Required]
        [Column("NUMCOLEGIADO")]
        public String numColegiado { get; set; }
        public virtual ICollection<Cita> citas { get; set; }
        public virtual ICollection<MedicoPaciente> pacientes {get; set;}
        public void addCita(Cita c){
            citas.Add(c);
        }
        public bool removeCita(Cita c){
            return citas.Remove(c);
        }
        public void addPaciente(Paciente p){
            pacientes.Add(new MedicoPaciente{medico =this, paciente=p});
        }
        public bool removePaciente(Paciente p){
            return pacientes.Remove(new MedicoPaciente{medico = this, paciente=p});
        }


    }
}