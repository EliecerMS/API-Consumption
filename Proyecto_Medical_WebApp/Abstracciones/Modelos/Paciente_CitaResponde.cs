namespace Abstracciones.Modelos
{
    public class Paciente_CitaResponde
    {
        public int IdPaciente { get; set; }
        public DateTime FechaCita { get; set; }
        public string Motivo { get; set; }
        public string Especialidad { get; set; }
        public string NombreDoctor { get; set; }

    }
}
