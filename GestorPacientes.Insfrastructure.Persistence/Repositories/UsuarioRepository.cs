using GestorPacientes.Core.Application.Helpers;
using GestorPacientes.Core.Application.Interfaces.Repositories;
using GestorPacientes.Core.Application.ViewModels.Usuario;
using GestorPacientes.Core.Domain.Entities;
using GestorPacientes.Insfrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace GestorPacientes.Insfrastructure.Persistence.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        private readonly ApplicationContext _dbContext;

        public UsuarioRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task AddAsync(Usuario entity)
        {
            entity.Clave = PasswordEncryptation.ComputeSha256Hash(entity.Clave);
            await base.AddAsync(entity);
        }
        public override async Task UpdateAsync(Usuario entity, int id)
        {
            entity.Clave = PasswordEncryptation.ComputeSha256Hash(entity.Clave);
            await base.UpdateAsync(entity, id);
        }
        public async Task<Usuario> LoginAsync(LoginViewModel loginViewModel)
        {
            string passwordEncrypt = PasswordEncryptation.ComputeSha256Hash(loginViewModel.Clave);            

            Usuario usuario = await _dbContext.Usuarios
                .FirstOrDefaultAsync(u => u.NombreUsuario == loginViewModel.NombreUsuario
                                    && u.Clave == passwordEncrypt);
            return usuario;
        }
        public async Task<bool> ExistsUsername(string nombreUsuario)
        {
            return await _dbContext.Usuarios.AnyAsync(u => u.NombreUsuario == nombreUsuario);
        }
        public async Task<bool> ExistsUsername(int id,string nombreUsuario)
        {
            return await _dbContext.Usuarios.AnyAsync(u => u.UsuarioId != id 
                                                    && u.NombreUsuario == nombreUsuario);
        }       
    }
}