namespace Abstracciones.Modelos
{
    public class Medico_Medicamento
    {

        public string Nombre { get; set; }
        public string Dosis { get; set; }
        public string Fecha { get; set; }
        public string Instrucciones { get; set; }

    }
    public class MedicamentoBD : Medico_Medicamento
    {
        public Guid Id_Medicamento { get; set; }
    }
}
