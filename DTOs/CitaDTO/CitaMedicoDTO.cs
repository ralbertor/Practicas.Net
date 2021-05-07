namespace Catalog.DTOs.CitaDTO
{
    public class CitaMedicoDTO{
        public long id {get; set;}
        public string numColegiado {get;set;}

        private string nombre1;

        public string Getnombre()
        {
            return nombre1;
        }

        public void Setnombre(string value)
        {
            nombre1 = value;
        }

        private string apellidos1;

        public string Getapellidos()
        {
            return apellidos1;
        }

        public void Setapellidos(string value)
        {
            apellidos1 = value;
        }

        public string nombre{get; set;}
        public string apellidos{get; set;}
        
    }
}