namespace Abstracciones.Modelos
{
    public class CitaDetallesBD
    {
        public int IdCita { get; set; }
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }
        public DateTime FechaHora { get; set; }
        public string Motivo { get; set; }
        public string Diagnostico { get; set; }
        public string Observaciones { get; set; }

    }
}
