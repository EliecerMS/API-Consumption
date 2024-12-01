namespace Abstracciones.Modelos
{
    public class Medico_EnfermedadDiagnostico
    {

        public string nombre { get; set; }
        public string fase_Enfermedad { get; set; }
        public string notas_Diagnostico { get; set; }

    }
    public class EnfermedadDiagnosticoBD : Medico_EnfermedadDiagnostico
    {
        public int id_EnferDiagnostico{ get; set; }
    }
}
