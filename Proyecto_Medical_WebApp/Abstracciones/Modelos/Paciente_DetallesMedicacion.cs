namespace Abstracciones.Modelos
{
    public class Paciente_DetallesMedicacion
    {
        public string NombreDoctor { get; set; }
        public string EmailDoctor { get; set; }
        public string NombrePadecimiento { get; set; }
        public string Dosis { get; set; }
        public string Intrucciones { get; set; }

        public string FechaPreescripcion { get; set; }
    }
}
