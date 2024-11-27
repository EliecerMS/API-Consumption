using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.Flujo
{
    public interface IMedicamentoFlujo
    {
        Task<IEnumerable<MedicamentoBD>> Obtener();
        Task<Medicamento> Obtener(Guid Id_Medicamento);

    }
}
