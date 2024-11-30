namespace Abstracciones.Modelos
{
    public class Medico_EnfermedadDiagnostico
    {

        public string Nombre { get; set; }
        public string Fase { get; set; }
        public string Notas { get; set; }

    }
    public class EnfermedadDiagnosticoBD : Medico_EnfermedadDiagnostico
    {
        public Guid Id_EnfermedadDiagnostico { get; set; }
    }
}
