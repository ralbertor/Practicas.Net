using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Entidades;

namespace Catalog.Repository
{
    public interface CitaRepository
    {
        Task<Cita> GetCitaAsync(long id);
        Task<IEnumerable<Cita>> GetCitasAsync();
        Task<long> CreateCitaAsync(Cita cita);
        Task UpdateCitaAsync(Cita cita);
        Task DeleteCitaAsync(long id);
    }
}