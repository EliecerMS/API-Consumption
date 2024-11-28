using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;

namespace Flujo
{
    public class MedicamentoFlujo : IMedicamentoFlujo

    {
        private IMedicamentoDA _medicamentoDA;
        private IFormatoHelper _formatoHelper;

        public MedicamentoFlujo(IMedicamentoDA medicamentoDA, IFormatoHelper formatoHelper)
        {
            _medicamentoDA = medicamentoDA;
            _formatoHelper = formatoHelper;
        }


        public async Task<IEnumerable<MedicamentoBD>> Obtener()
        {
            var medicamentosSinformato = await _medicamentoDA.Obtener();
            if (!medicamentosSinformato.Any())
                return medicamentosSinformato;
            return _formatoHelper.DarFormatoListaMedicamentos(medicamentosSinformato);
        }

        public async Task<Medicamento> Obtener(Guid Id_Medicamento)
        {
            var medicamentoSinformato = await _medicamentoDA.Obtener(Id_Medicamento);
            if (medicamentoSinformato == null)
                return null;
            return _formatoHelper.DarFormatoMedicamento(medicamentoSinformato);
        }
    }
}
