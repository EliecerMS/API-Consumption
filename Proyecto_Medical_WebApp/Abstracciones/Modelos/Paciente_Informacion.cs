namespace Abstracciones.Modelos
{
    public class Paciente_Informacion
    {
        public int estatura { get; set; }
        public string cedula { get; set; }
    }

    public class Paciente_InformacionBD : Paciente_Informacion
    {
        public int id_Paciente { get; set; }
    }
}
