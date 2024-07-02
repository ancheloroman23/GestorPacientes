using System.ComponentModel.DataAnnotations;

namespace GestorPacientes.Core.Application.ViewModels.ResultadoLab
{
    public class ResultadoLabSaveViewModel
    {
        public string? Resultado { get; set; }
        public  string Estado { get; set; }

        [Required]
        public int CitaId { get; set; }
        [Required]
        public int PruebaLabId { get; set; }        
    }
}
