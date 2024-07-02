using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace GestorPacientes.Core.Application.ViewModels.Doctor
{
    public class DoctorSaveViewModel
    {
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "Digite un nombre, Por favor")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "Digite un apellido, Por favor")]
        [DataType(DataType.Text)]
        public string Apellido { get; set; }


        [Required(ErrorMessage = "Digite un correo, Por favor")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Digite un numero de telefono, Por favor")]
        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }


        [Required(ErrorMessage = "Digite su cedula, Por favor")]
        [DataType(DataType.Text)]
        public string Cedula { get; set; }

        public string? Foto { get; set; }


        
        [DataType(DataType.Upload)]
        public IFormFile? Imagen { get; set; }

    }
}