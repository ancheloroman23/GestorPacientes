using GestorPacientes.Core.Application.ViewModels.PruebaLab;
using System.ComponentModel.DataAnnotations;

namespace GestorPacientes.Core.Application.ViewModels.Cita
{
    public class CitaConsultaViewModel
    {
        [Key]
        [Required]
        public int CitaId { get; set; }        
        public IEnumerable<PruebaLabViewModel>? PruebaLabs { get; set; }
        public List<int>? PruebaLabSeleccionada { get; set; }
    }
}
