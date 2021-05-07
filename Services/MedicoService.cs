using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Entidades;

namespace Catalog.Services
{
    public interface MedicoService
    {
        public Task<ICollection<Medico>> findAllAsync();
        public Task<Medico> findByIdAsync(long id);
        public Task<Medico> getRandom();
        public Task<long?> saveAsync(Medico med);
        public Task<bool> deleteAsync(long id);
        public Task<bool> updateAsync(Medico med);
    }
}