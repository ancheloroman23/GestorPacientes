using GestorPacientes.Core.Application.ViewModels.Cita;
using System.ComponentModel.DataAnnotations;

namespace GestorPacientes.Core.Application.ViewModels.Paciente
{
    public class PacienteViewModel
    {
        [Key]
        public int PacienteId { get; set; }
        public string Nombre { get; set; }
        public  string Apellido { get; set; }
        public  DateOnly FechaNacimiento { get; set; }
        public  string Cedula { get; set; }
        public  string Direccion { get; set; }
        public  string Telefono { get; set; }
        public  string NombreUsuario { get; set; }
        public  string Email { get; set; }
        public  string Clave { get; set; }
        public  string Foto { get; set; }
        public bool Fumador { get; set; }
        public bool Alergico { get; set; }

        public IEnumerable<CitaViewModel>? Citas { get; set; }
    }
}
