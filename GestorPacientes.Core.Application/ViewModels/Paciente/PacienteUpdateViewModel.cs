using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace GestorPacientes.Core.Application.ViewModels.Paciente
{
    public class PacienteUpdateViewModel
    {
        [Required]
        public int PacienteId { get; set; }


        [Required(ErrorMessage = "Digite un nombre, Por favor")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "Digite un apellido, Por favor")]
        [DataType(DataType.Text)]
        public string Apellido { get; set; }


        [Required(ErrorMessage = "Digite una fecha de nacimiento, Por favor")]
        [DataType(DataType.Date)]
        public DateOnly FechaNacimiento { get; set; }


        [Required(ErrorMessage = "Digite su cedula, Por favor")]
        [DataType(DataType.Text)]
        public string Cedula { get; set; }


        [Required(ErrorMessage = "Digite su direccion, Por favor")]
        [DataType(DataType.Text)]
        public string Direccion { get; set; }


        [Required(ErrorMessage = "Digite un numero de telefono, Por favor")]
        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }

        public string? Foto { get; set; }

        [Required(ErrorMessage = "Coloca una foto")]
        [DataType(DataType.Upload)]
        public IFormFile Imagen { get; set; }

        public bool Fumador { get; set; }
        public bool Alergico { get; set; }
    }
}
