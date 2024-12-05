namespace Abstracciones.Modelos
{
    public class Medico_PacientesPadecimientos
    {
        public string NombreCompletoPaciente { get; set; }
        public string Enfermedad { get; set; }
    }

    public class PacientesPadecimientosBD : Medico_PacientesPadecimientos
    {
        public int IdEnfermedadDiagnostico { get; set; }
    }
}
