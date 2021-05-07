using System.Collections.Generic;

namespace Catalog.DTOs.PacienteDTO
{
    public class PacienteDTO{
        public string Nss{get;set;}
        public string numTarjeta{get;set;}
        public string telefono{get;set;}
        public string direccion{get;set;}
        public ICollection<CitaDTO> cita{get;set;}
        public ICollection<MedicoOnlyDTO> medico {get;set;}
        public long id{get;set;}
        public string nombre{get;set;}
        public string apellidos{get;set;}
        public string usuario{get;set;}
        public string clave{get;set;}
    }
}