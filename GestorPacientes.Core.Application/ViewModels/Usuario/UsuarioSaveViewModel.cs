using System.ComponentModel.DataAnnotations;

namespace GestorPacientes.Core.Application.ViewModels.Usuario
{
    public class UsuarioSaveViewModel
    {
        [Required(ErrorMessage = "Colocar un nombre, Por favor")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "Colocar un apellido, Por favor")]
        [DataType(DataType.Text)]
        public string Apellido { get; set; }


        [Required(ErrorMessage = "Colocar un correo, Por favor")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Colocar un nombre de usuario, Por favor")]
        [DataType(DataType.Text)]
        public string NombreUsuario { get; set; }


        [Required(ErrorMessage = "Colocar una contraseña, Por favor")]
        [DataType(DataType.Password)]
        public string Clave { get; set; }


        [Compare(nameof(Clave), ErrorMessage = "La Clave no coiciden")]
        [Required(ErrorMessage = "Colocar una contraseña, Por favor")]
        [DataType(DataType.Password)]
        public string ConfirmarClave { get; set; }


        [Required(ErrorMessage = "Escoja una opcion, Por favor")]
        public string TipoUsuario { get; set; }
    }
}