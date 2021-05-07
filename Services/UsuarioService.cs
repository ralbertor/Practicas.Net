using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Entidades;

namespace Catalog.Services
{
    public interface UsuarioService
    {
        public Task<Usuario> findByUsuarioAsync(String usuario);
    }
}