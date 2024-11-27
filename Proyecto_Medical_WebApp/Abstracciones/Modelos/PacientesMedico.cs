namespace Abstracciones.Modelos
{
    public class PacientesMedico
    {
        public string nombre { get; set; }
        public int estatura { get; set; }
        public int peso { get; set; }
        public string motivo { get; set; }
        public string fecha_Cita { get; set; }
        public string Padecimiento { get; set; }
    }

    public class PacientesMedicoBD : PacientesMedico
    {
        public int id_Paciente { get; set; }
    }
}
