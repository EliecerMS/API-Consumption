namespace Abstracciones.Modelos
{
    public class PacientesPadecimientos
    {
        public string NombreCompletoPaciente { get; set; }
        public string Enfermedad { get; set; }
    }

    public class PacientesPadecimientosBD : PacientesPadecimientos
    {
        public int idEnfermedadDiagnostico { get; set; }
    }
}
