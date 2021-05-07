using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Entidades;

namespace Catalog.Repository
{
    public interface MedicoRepository
    {
        Task<Medico> GetMedicoAsync(long id);
        Task<IEnumerable<Medico>> GetMedicosAsync();
        Task<Medico> GetMedicoRandomAsync();
        Task<long> CreateMedicoAsync(Medico diag);
        Task UpdateMedicoAsync(Medico diag);
        Task DeleteMedicoAsync(long id);
    }
}