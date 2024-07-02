using System.ComponentModel.DataAnnotations;

namespace GestorPacientes.Core.Domain.Entities
{
    public class PruebaLab
    {       
        public int PruebaLabId { get; set; }
        public string NombrePruebaLab { get; set; }

        public ICollection<ResultadoLab>? ResultadosLabs { get; set; }
    }
}
