namespace Abstracciones.Modelos
{
    public class MedicacionPacienteMapping
    {
        public int id_Medicacion_Paciente { get; set; }

        public int id_Medicamento { get; set; }

        public int id_Cita { get; set; }

        public string dosis { get; set; }

        public string intrucciones { get; set; }

        public string fecha_Preesctrito { get; set; }

    }
}
