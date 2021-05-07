using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Entidades;
using Catalog.Repository;
using Catalog.Services;

namespace Catalog.ServicesImp
{
    public class UsuarioServiceImp :UsuarioService
    {
        private readonly UsuarioRepository repository;
        public UsuarioServiceImp(UsuarioRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Usuario> findByUsuarioAsync(string usuario)
        {
            try {
                return await repository.GetUsuarioByUsuarioAsync(usuario);
            } catch (Exception) {
                return null;
            }
        }
    }
}