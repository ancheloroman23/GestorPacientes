using GestorPacientes.Core.Application.ViewModels.Doctor;
using GestorPacientes.Core.Application.ViewModels.Paciente;
using GestorPacientes.Core.Application.ViewModels.ResultadoLab;

namespace GestorPacientes.Core.Application.ViewModels.Cita
{
    public class CitaViewModel
    {
        public int CitaId { get; set; }
        public int PacienteId { get; set; }
        public int DoctorId { get; set; }
        public DateTime FechaCita { get; set; }
        public required string RazonCita { get; set; }
        public required string EstadoCita { get; set; }
        
        public PacienteViewModel? Paciente { get; set; }
        public DoctorViewModel? Doctor { get; set; }
        public IEnumerable<ResultadoLabViewModel>? ResultadosLabs { get; set; }
    }
}