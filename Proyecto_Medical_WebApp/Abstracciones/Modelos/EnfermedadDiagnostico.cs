namespace Abstracciones.Modelos
{
    public class EnfermedadDiagnostico
    {

        public string Nombre { get; set; }
        public string Fase { get; set; }
        public string Notas { get; set; }

    }
    public class EnfermedadDiagnosticoBD : EnfermedadDiagnostico
    {
        public Guid Id_EnfermedadDiagnosticoBD { get; set; }
    }
}
