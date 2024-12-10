namespace Abstracciones.Modelos
{
    public class Medico_DetallesPaciente
    {
        public string Medicamento { get; set; }
        public string Enfermedad { get; set; }
        public string fase_Enfermedad { get; set; }
        public int peso { get; set; }
        public int estatura { get; set; }
        public Guid id_Paciente { get; set; }
    }
}
