namespace Abstracciones.Modelos
{
    public class Persona
    {
        public Guid id_Persona { get; set; }
        public string nombre { get; set; }
        public string primer_Apellido { get; set; }
        public string segundo_Apellido { get; set; }
        public DateTime fecha_Nacimiento { get; set; }
        public string genero { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string edad { get; set; }
        public string identificacion { get; set; }
        public string rol { get; set; }
    }
}
