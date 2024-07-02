using System.ComponentModel.DataAnnotations;

namespace GestorPacientes.Core.Application.ViewModels.Usuario
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Colocar el nombre de usuario, Por favor")]
        [DataType(DataType.Text)]
        public required string NombreUsuario { get; set; }


        [Required(ErrorMessage = "Colocar una contraseña, Por favor")]
        [DataType(DataType.Password)]
        public required string Clave { get; set; }
    }
}
