using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Entidades;

namespace Catalog.Services
{
    public interface PacienteService
    {
        public Task<ICollection<Paciente>> findAllAsync();
        public Task<Paciente> findByIdAsync(long id);
        public Task<long?> saveAsync(Paciente pac);
        public Task<bool> deleteAsync(long id);
        public Task<bool> updateAsync(Paciente pac);
    }
}
