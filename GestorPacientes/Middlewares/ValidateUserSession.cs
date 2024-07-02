using GestorPacientes.Core.Application.ViewModels.Usuario;
using GestorPacientes.Core.Application.Helpers;

namespace GestorPacientes.Middlewares
{
    public class ValidateUserSession
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ValidateUserSession(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool Administrador()
        {
            UsuarioViewModel vm = _httpContextAccessor.HttpContext.Session.Get<UsuarioViewModel>("usuario");
            return (vm != null && vm.TipoUsuario == "Administrador");
        }

        public bool Asistente()
        {
            UsuarioViewModel vm = _httpContextAccessor.HttpContext.Session.Get<UsuarioViewModel>("usuario");
            return (vm != null && vm.TipoUsuario == "Asistente");
        }

        public bool HasUser()
        {
            UsuarioViewModel vm = _httpContextAccessor.HttpContext.Session.Get<UsuarioViewModel>("usuario");
            return (vm != null);
        }
    }
}