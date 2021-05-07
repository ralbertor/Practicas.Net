namespace Catalog.DTOs.DiagnosticoDTO
{
    public class DiagnosticoDTO{
    public int id {get;set;}
	public string enfermedad{get;set;}
	public string valoracionEspecialista{get;set;}

    public CitaDTO cita{get;set;}
    }
}