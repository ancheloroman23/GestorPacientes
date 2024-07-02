using GestorPacientes.Core.Application.ViewModels.Doctor;
using GestorPacientes.Core.Application.ViewModels.Paciente;
using System.ComponentModel.DataAnnotations;

namespace GestorPacientes.Core.Application.ViewModels.Cita
{
    public class CitaSaveViewModel
    {
        public int PacienteId { get; set; }
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una fecha y hora")]
        [DataType(DataType.DateTime)]
        public DateTime FechaCita { get; set; }

        [Required(ErrorMessage = "Debe colocar la causa")]
        [DataType(DataType.Text)]
        public string RazonCita { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string EstadoCita { get; set; }
        public IEnumerable<PacienteViewModel>? Pacientes { get; set; }
        public IEnumerable<DoctorViewModel>? Doctores { get; set; }    
    }
}