
namespace GestorPacientes.Core.Application.ViewModels.Usuario
{
    public class UsuarioViewModel
    {        
        public int UsuarioId { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string NombreUsuario { get; set; }
        public required string Email { get; set; }
        public required string Clave { get; set; }
        public required string TipoUsuario { get; set; }
    }
}
