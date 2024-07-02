

namespace GestorPacientes.Core.Domain.Entities
{
    public class ResultadoLab
    {

        public int ResultadosLabId { get; set; }        
        public int CitaId { get; set; }
        public int PruebaLabId { get; set; }
        public int PacienteId { get; set; }
        public string? Resultado { get; set; }
        public required string Estado { get; set; }
        

        public Paciente? Paciente { get; set; }
        public Cita? Cita { get; set; }
        public PruebaLab? PruebaLab { get; set; }
    }
}
