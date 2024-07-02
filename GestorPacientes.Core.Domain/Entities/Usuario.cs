using System.ComponentModel.DataAnnotations;

namespace GestorPacientes.Core.Domain.Entities
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set; }
        public string Email { get; set; }        
        public string Clave { get; set; }
        public string TipoUsuario { get; set; }            
    }
}
