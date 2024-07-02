using System.ComponentModel.DataAnnotations;

namespace GestorPacientes.Core.Application.ViewModels.PruebaLab
{
    public class PruebaLabUpdateViewModel
    {
        [Key]
        [Required]
        public int PruebaLabId { get; set; }

        [Required(ErrorMessage = "Digite un nombre, Por favor")]
        [DataType(DataType.Text)]
        public  string NombrePruebaLab { get; set; }
    }
}
