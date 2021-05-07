using System;
using Catalog.Entidades;

namespace Catalog.DTOs.MedicoDTO
{
    public class MedicoCitaDTO{
        public long id{get;set;}
        public DateTime? fechaHora{get;set;}
        public string motivo{get;set;}
        public MedicoPacienteDTO pacienteDTO{get;set;}
        public string nombre{get;set;}
        public string apellidos{get;set;}
        public string usuario{get;set;}
        public string clave{get;set;}

        private Diagnostico diagnostico1;

        public Diagnostico Getdiagnostico()
        {
            return diagnostico1;
        }

        public void Setdiagnostico(Diagnostico value)
        {
            diagnostico1 = value;
        }
    }
}