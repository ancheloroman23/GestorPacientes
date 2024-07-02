using System.ComponentModel.DataAnnotations;

namespace GestorPacientes.Core.Application.ViewModels.Cita
{
    public class CitaUpdateViewModel
    {
        [Required]
        public int CitaId { get; set; }

        [Required(ErrorMessage = "Digite un paciente")]
        public int PacienteId { get; set; }

        [Required(ErrorMessage = "Digitw un doctor")]
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "Seleccione fecha & hora, Por favor")]
        [DataType(DataType.DateTime)]
        public DateTime FechaCita { get; set; }

        [Required(ErrorMessage = "Digite la razon de cita, Por favor")]
        [DataType(DataType.Text)]
        public string RazonCita { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string EstadoCita { get; set; }
    }
}