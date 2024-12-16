namespace Abstracciones.Modelos
{
    public class Medico_PacienteMedicamento
    {
        public Guid Id { get; set; }
        public string NombrePaciente { get; set; }
        public string NombreMedicamento { get; set; }

    }
    public class PacienteMedicamentoBD : Medico_PacienteMedicamento
    {
        public int Id_Medicacion_Paciente { get; set; }
    }
}
