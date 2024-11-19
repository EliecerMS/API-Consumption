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

        public async Task<DetallesPaciente> ObtenerDetallesPaciente(int IdPaciente)
        {
            var detallesPacienteSinformato = await _medicoDA.ObtenerDetallesPaciente(IdPaciente);
            if (detallesPacienteSinformato == null)
                return null;
            return _formatoHelper.DarFormatoDetallesPaciente(detallesPacienteSinformato);
        }

        public async Task<IEnumerable<PacientesMedicoBD>> ObtenerListaPacientes(int idMedico)
        {
            var pacientesSinformato = await _medicoDA.ObtenerListaPacientes(idMedico);
            if (!pacientesSinformato.Any())
                return pacientesSinformato;
            return _formatoHelper.DarFormatoListaPacientes(pacientesSinformato);
        }

        public async Task<IEnumerable<PacientesPadecimientosBD>> ObtenerListaPacientesYPadecimientos(int medicoId)
        {
            var pacientesYPadecimientosSinformato = await _medicoDA.ObtenerListaPacientesYPadecimientos(medicoId);
            if (!pacientesYPadecimientosSinformato.Any())
                return pacientesYPadecimientosSinformato;
            return _formatoHelper.DarFormatoListaPacientesYPadecimientos(pacientesYPadecimientosSinformato);
        }
    }
}
