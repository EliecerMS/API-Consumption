namespace Abstracciones.Interfaces.Reglas
{
    public interface IConfiguracion
    {
        string ObtenerMetodo(string nombre);
        string ObtenerMetodo(string seccion, string nombre);
    }
}
