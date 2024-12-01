namespace Abstracciones.Modelos
{
    public class Medico_PacienteMedicamento
    {

        public string NombrePaciente { get; set; }
        public string NombreMedicamento { get; set; }

    }
    public class PacienteMedicamentoBD : Medico_PacienteMedicamento
    {
        public int id_Medicacion_Paciente { get; set; }
    }
}
