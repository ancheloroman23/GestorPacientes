using System.ComponentModel.DataAnnotations;

namespace GestorPacientes.Core.Application.ViewModels.ResultadoLab
{
    public class ResultadoLabUpdateViewModel
    {

        [Required]
        public int ResultadoLabId { get; set; }
        [Required]
        public int CitaId { get; set; }
        [Required]
        public int PruebaLabId { get; set; }

        [Required(ErrorMessage = "Digite los resultados")]
        public string Resultado { get; set; }
        [Required]
        public required string Estado { get; set; }

       
    }
}
