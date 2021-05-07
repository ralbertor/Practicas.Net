using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Entidades;

namespace Catalog.Repository
{
    public interface PacienteRepository
    {
        Task<Paciente> GetPacienteAsync(long id);
        Task<IEnumerable<Paciente>> GetPacientesAsync();
        Task<long> CreatePacienteAsync(Paciente pac);
        Task UpdatePacienteAsync(Paciente pac);
        Task DeletePacienteAsync(long id);
    }
}