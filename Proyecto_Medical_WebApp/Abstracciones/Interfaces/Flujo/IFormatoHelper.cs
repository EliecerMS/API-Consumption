using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.Flujo
{
    public interface IFormatoHelper
    {

        IEnumerable<PacientesMedicoBD> DarFormatoListaPacientes(IEnumerable<PacientesMedicoBD> pacientesSinFormato);

    }
}
