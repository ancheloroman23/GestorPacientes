using GestorPacientes.Core.Application.ViewModels.Usuario;
using GestorPacientes.Core.Domain.Entities;

namespace GestorPacientes.Core.Application.Interfaces.Services
{
    public interface IUsuarioService : IGenericService<UsuarioViewModel,
                                                       UsuarioSaveViewModel,
                                                       UsuarioUpdateViewModel,
                                                       Usuario>
    {
        Task<UsuarioViewModel> Login(LoginViewModel viewModel);
        Task<bool> ExistsUsername(UsuarioSaveViewModel viewModel);
        Task<bool> ExistsUsername(UsuarioUpdateViewModel viewModel);
    }
}
