using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.DA
{
    public interface IEnfermedadDiagnosticoDA
    {
        Task<IEnumerable<EnfermedadDiagnosticoBD>> Obtener();

        Task<EnfermedadDiagnosticoBD> Obtener(Guid Id_EnfermedadDiagnosticoBD);

    }
}
