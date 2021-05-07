using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Entidades;

namespace Catalog.Repository
{
    public interface DiagnosticoRepository
    {
        Task<Diagnostico> GetDiagnosticoAsync(long id);
        Task<IEnumerable<Diagnostico>> GetDiagnosticosAsync();
        Task<long> CreateDiagnosticoAsync(Diagnostico diag);
        Task UpdateDiagnosticoAsync(Diagnostico diag);
        Task DeleteDiagnosticoAsync(long id);
    }
}