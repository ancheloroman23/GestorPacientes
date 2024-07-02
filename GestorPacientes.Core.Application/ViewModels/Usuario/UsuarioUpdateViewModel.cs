using System.ComponentModel.DataAnnotations;

namespace GestorPacientes.Core.Application.ViewModels.Usuario
{
    public class UsuarioUpdateViewModel
    {
        [Required]
        public int UsuarioId { get; set; }


        [Required(ErrorMessage = "Digite un nombre, Por favor")]
        [DataType(DataType.Text)]
        public required string Nombre { get; set; }


        [Required(ErrorMessage = "Digite un apellido, Por favor")]
        [DataType(DataType.Text)]
        public required string Apellido { get; set; }


        [Required(ErrorMessage = "Digite un nombre de usuario, Por favor")]
        [DataType(DataType.Text)]
        public required string NombreUsuario { get; set; }


        [Required(ErrorMessage = "Digite un correo, Por favor")]
        [DataType(DataType.EmailAddress)]
        public required string Email { get; set; }        


        [Required(ErrorMessage = "Digite una Clave, Por favor")]
        [DataType(DataType.Text)]
        public required string Clave { get; set; }


        [Compare(nameof(Clave), ErrorMessage = "La Clave no coiciden")]
        [DataType(DataType.Text)]
        public required string ConfirmarClave { get; set; }


        [Required(ErrorMessage = "Escoja una opcion, Por favor")]
        public string TipoUsuario { get; set; }
    }
}
