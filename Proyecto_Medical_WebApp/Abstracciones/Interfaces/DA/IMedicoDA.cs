using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.DA
{
    public interface IMedicoDA
    {
        Task<IEnumerable<PacientesMedicoBD>> ObtenerListaPacientes(int medicoId);
    }
}
