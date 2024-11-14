using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;

namespace Flujo
{
    public class MedicoFlujo : IMedicoFlujo
    {
        private IMedicoDA _medicoDA;
        private IFormatoHelper _formatoHelper;

        public MedicoFlujo(IMedicoDA medicoDA, IFormatoHelper formatoHelper)
        {
            _medicoDA = medicoDA;
            _formatoHelper = formatoHelper;
        }

        public async Task<IEnumerable<PacientesMedicoBD>> ObtenerListaPacientes(int idMedico)
        {
            var pacientesSinformato = await _medicoDA.ObtenerListaPacientes(idMedico);
            if (!pacientesSinformato.Any())
                return pacientesSinformato;
            return _formatoHelper.DarFormatoListaPacientes(pacientesSinformato);
        }
    }
}
