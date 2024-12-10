namespace Abstracciones.Modelos
{
    public class Paciente_ListaPadecimientos
    {
        public string NombreEnfermedad { get; set; }
        public string fecha_Diagnostico { get; set; }
        public string MotivoCita { get; set; }

    }

    public class PacientePadecimientosBD : Paciente_ListaPadecimientos
    {

        public int id_EnferDiagnostico { get; set; }

        public int id_Cita { get; set; }
    }
}
