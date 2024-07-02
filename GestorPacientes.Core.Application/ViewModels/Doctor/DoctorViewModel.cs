using GestorPacientes.Core.Application.ViewModels.Cita;
using System.ComponentModel.DataAnnotations;

namespace GestorPacientes.Core.Application.ViewModels.Doctor
{
    public class DoctorViewModel
    {
        [Key]
        public int DoctorId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Cedula { get; set; }
        public string Foto { get; set; }


        public IEnumerable<CitaViewModel>? Citas { get; set; }
    }
}
