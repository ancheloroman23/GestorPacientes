using GestorPacientes.Core.Application.ViewModels.Cita;
using GestorPacientes.Core.Application.ViewModels.PruebaLab;

namespace GestorPacientes.Core.Application.ViewModels.ResultadoLab
{
    public class ResultadoLabViewModel
    {
        public int ResultadosLabId { get; set; }
        public int CitaId { get; set; }
        public int PruebaLabId { get; set; }
        public string? Resultado { get; set; }
        public required string Estado { get; set; }
        public string NombrePaciente { get; set; }
        public string Cedula { get; set; }
        public string NombrePruebaLab { get; set; }


        public CitaViewModel? Cita { get; set; }
        public PruebaLabViewModel? PruebaLab { get; set; }
        
    }
}
