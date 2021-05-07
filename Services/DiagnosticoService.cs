using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Entidades;

namespace Catalog.Services
{
    public interface DiagnosticoService
    {
        public Task<ICollection<Diagnostico>> findAllAsync();
        public Task<Diagnostico> findByIdAsync(long id);
        public Task<long?> saveAsync(Diagnostico diag);
        public Task<bool> deleteAsync(long id);
        public Task<bool> updateAsync(Diagnostico diag);
    }
}