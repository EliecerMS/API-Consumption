namespace Abstracciones.Modelos
{
    public class Medico_Medicamento
    {

        public string nombre { get; set; }
        public string dosis { get; set; }
        public string fecha_Preesctrito { get; set; }
        public string intrucciones { get; set; }

    }
    public class MedicamentoBD : Medico_Medicamento
    {
        public int id_Medicamento { get; set; }
    }
}
