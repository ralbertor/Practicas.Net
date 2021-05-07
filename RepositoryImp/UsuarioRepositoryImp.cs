using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Entidades;
using Catalog.Repository;
using Microsoft.EntityFrameworkCore;

namespace Catalog.RepositoryImp
{
    public class UsuarioRepositoryImp : UsuarioRepository
    {   
        private readonly OracleContext oracle;
        public UsuarioRepositoryImp(OracleContext oracle){
            this.oracle=oracle;
        }   

        public async Task<Usuario> GetUsuarioByUsuarioAsync(string usuario)
        {
             return await oracle.OracleUsuario.Where(u => u.usuario.Equals(usuario)).FirstOrDefaultAsync();
        }
    }


}