using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.Flujo
{
    public interface IEnfermedadDiagnosticoFlujo
    {
        Task<IEnumerable<EnfermedadDiagnosticoBD>> Obtener();


        Task<EnfermedadDiagnostico> Obtener(Guid Id_EnfermedadDiagnosticoBD);

    }
}
