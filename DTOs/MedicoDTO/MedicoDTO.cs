using System.Collections.Generic;

namespace Catalog.DTOs.MedicoDTO
{
    public class MedicoDTO{
        public long id;
        public string numColegiado;
        public string nombre;
        public string apellidos;
        public string usuario;
        public string clave;
        public ICollection<PacienteOnlyDTO> paciente{get;set;}
        public ICollection<CitaDTO> citaDTOs{get;set;}
    }
}