namespace Abstracciones.Modelos
{
    public class EnfermedaDiagnosticoMapping
    {
        public int id_EnferDiagnostico { get; set; }

        public int id_Cita { get; set; }

        public int id_Enfermedad { get; set; }

        public string notas_Diagnostico { get; set; }

        public string fase_Enfermedad { get; set; }

        public string fecha_Diagnostico { get; set; }
    }
}
