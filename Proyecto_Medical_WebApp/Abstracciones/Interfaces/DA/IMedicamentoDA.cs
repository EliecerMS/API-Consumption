using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.DA
{
    public interface IMedicamentoDA
    {
        Task<IEnumerable<MedicamentoBD>> Obtener();
        Task<MedicamentoBD> Obtener(Guid Id_Medicamento);


    }
}
