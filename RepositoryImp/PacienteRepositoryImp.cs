using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Entidades;
using Microsoft.EntityFrameworkCore;
using Catalog.Repository;

namespace Catalog.RepositoryImpl
{
    public class PacienteRepositoryImp : PacienteRepository
    {
        private readonly OracleContext _context;
        public PacienteRepositoryImp(OracleContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Paciente>> GetPacientesAsync()
        {
            return await _context.OraclePaciente.ToListAsync();
        }
        public async Task<Paciente> GetPacienteAsync(long id)
        {
            return await _context.OraclePaciente.FindAsync(id);
        }
        public async Task<long> CreatePacienteAsync(Paciente pac)
        {
            var pacCreated = await _context.OraclePaciente.AddAsync(pac);
            await _context.SaveChangesAsync();
            return pacCreated.Entity.id;
        }
        public async Task UpdatePacienteAsync(Paciente pac)
        {
            var pacUpdated = _context.OraclePaciente.Update(pac);
            await _context.SaveChangesAsync();
        }
        public async Task DeletePacienteAsync(long id)
        {
            var pac = await _context.OraclePaciente.FindAsync(id);
            if (pac == null)
                await Task.CompletedTask;
            _context.OraclePaciente.Remove(pac);
            await _context.SaveChangesAsync();
        }



    }
}