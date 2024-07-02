using GestorPacientes.Core.Application.ViewModels.ResultadoLab;
using System.ComponentModel.DataAnnotations;

namespace GestorPacientes.Core.Application.ViewModels.PruebaLab
{
    public class PruebaLabViewModel
    {
        [Key]
        public int PruebaLabId { get; set; }
        public  string NombrePruebaLab { get; set; }

        public ICollection<ResultadoLabViewModel>? ResultadosLabs { get; set; }
    }
}
