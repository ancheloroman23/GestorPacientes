using System.ComponentModel.DataAnnotations;

namespace GestorPacientes.Core.Domain.Entities
{
    public class Paciente
    {        
        public int PacienteId { get; set; }        
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateOnly FechaNacimiento { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
             
        public string? Foto { get; set; }
        public bool Fumador { get; set; }
        public bool Alergico { get; set; }


        public ICollection<Cita>? Citas { get; set; }
        public ICollection<ResultadoLab>? ResultadosLab { get; set; }
    }
}
