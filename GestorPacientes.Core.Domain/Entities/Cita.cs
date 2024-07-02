using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorPacientes.Core.Domain.Entities
{
    public class Cita
    {        
        public int CitaId { get; set; }
        public DateTime FechaCita { get; set;}
        public string RazonCita { get; set;}
        public string EstadoCita { get; set; }
        
        public int DoctorId { get; set; }
        
        public int PacienteId { get; set; }


        public ICollection<ResultadoLab>? ResultadosLabs { get; set; }
        public Paciente? Paciente { get; set; }    
        public Doctor? Doctor { get; set; } 

    }
}
