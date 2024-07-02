using AutoMapper;
using GestorPacientes.Core.Application.Interfaces.Repositories;
using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.ViewModels.Usuario;
using GestorPacientes.Core.Domain.Entities;

namespace GestorPacientes.Core.Application.Services
{
    public class UsuarioService : GenericService<UsuarioViewModel,
                                                 UsuarioSaveViewModel,
                                                 UsuarioUpdateViewModel,
                                                 Usuario>,IUsuarioService
    {
        private readonly IUsuarioRepository _usuariorepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _usuariorepository = repository;
            _mapper = mapper;
        }

        public async Task<bool> ExistsUsername(UsuarioSaveViewModel viewModel)
        {
            return await _usuariorepository.ExistsUsername(viewModel.NombreUsuario);
        }

        public async Task<bool> ExistsUsername(UsuarioUpdateViewModel viewModel)
        {
            return await _usuariorepository.ExistsUsername(viewModel.UsuarioId, viewModel.NombreUsuario);
        }

        public async Task<UsuarioViewModel> Login(LoginViewModel viewModel)
        {
            Usuario usuario = await _usuariorepository.LoginAsync(viewModel);

            if (usuario == null)
                return null;

            UsuarioViewModel loginVm = _mapper.Map<UsuarioViewModel>(usuario);
            return loginVm;
        }

        
    }
}
