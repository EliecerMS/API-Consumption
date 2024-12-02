namespace Abstracciones.Modelos
{
    public class Medico_Medicamento
    {

        public string NombreMedicamento { get; set; }
        public string Dosis { get; set; }
        public string FechaPrescrito { get; set; }
        public string Instrucciones { get; set; }

    }
    public class MedicamentoBD : Medico_Medicamento
    {
        public int id_Medicamento { get; set; }
    }
}
