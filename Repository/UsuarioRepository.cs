  
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Entidades;

namespace Catalog.Repository
{
    public interface UsuarioRepository
    {
        Task<Usuario> GetUsuarioByUsuarioAsync(string usuario);
    }
}