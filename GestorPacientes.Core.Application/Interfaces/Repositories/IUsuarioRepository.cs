using GestorPacientes.Core.Application.ViewModels.Usuario;
using GestorPacientes.Core.Domain.Entities;

namespace GestorPacientes.Core.Application.Interfaces.Repositories
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        Task<Usuario> LoginAsync(LoginViewModel loginViewModel);
        Task<bool> ExistsUsername(string nombreUsuario);
        Task<bool> ExistsUsername(int id, string nombreUsuario);
    }
}
