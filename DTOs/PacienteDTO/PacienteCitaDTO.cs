using System;
using Catalog.Entidades;

namespace Catalog.DTOs.PacienteDTO
{
    public class PacienteCitaDTO{
        public DateTime? fechaHora{get;set;}
        public string motivo{get;set;}
        public Diagnostico diagnostico{get;set;}
        
        public PacienteMedicoDTO medico {get;set;}
        public long id{get;set;}
        public string nombre{get;set;}
        public string apellidos{get;set;}
        public string usuario{get;set;}
        public string clave{get;set;}
    }
}