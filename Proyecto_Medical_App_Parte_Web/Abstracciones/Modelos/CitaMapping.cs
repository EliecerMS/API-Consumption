namespace Abstracciones.Modelos
{
    public class CitaMapping
    {
        public int id_Cita { get; set; }
        public Guid id_Medico { get; set; }
        public Guid id_Paciente { get; set; }
        public string fecha_Cita { get; set; }
        public string motivo { get; set; }
        public string especialidad { get; set; }
        public string notas_Cita { get; set; }
        public Boolean atendida { get; set; }
    }
}
