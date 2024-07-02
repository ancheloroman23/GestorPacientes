using System.ComponentModel.DataAnnotations;

namespace GestorPacientes.Core.Domain.Entities
{
    public class Doctor
    {        
        public int DoctorId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Cedula { get; set; }
        public string? Foto { get; set; }


        public ICollection<Cita>? Citas { get; set; }
    }
}
