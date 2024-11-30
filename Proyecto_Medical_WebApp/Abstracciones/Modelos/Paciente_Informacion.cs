namespace Abstracciones.Modelos
{
    public class Paciente_Informacion
    {
        public string nombre { get; set; }
        public string primer_Apellido { get; set; }
        public string segundo_Apellido { get; set; }
        public string fecha_Nacimiento { get; set; }
        public string genero { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string edad { get; set; }
        public int peso { get; set; }
        public int estatura { get; set; }
        public string cedula { get; set; }
    }

    public class Paciente_InformacionBD : Paciente_Informacion
    {
        public int id_Paciente { get; set; }
    }
}
