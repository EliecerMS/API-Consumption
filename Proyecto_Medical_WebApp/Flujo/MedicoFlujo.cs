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

        public async Task<int> EditarPesoAlturaPaciente(int IdPaciente, Medico_PesoAltura pacienteInformacion)
        {
            var resultado = await _medicoDA.EditarPesoAlturaPaciente(IdPaciente, pacienteInformacion);
            return resultado;
        }

        public async Task<Medico_DetallesPaciente> ObtenerDetallesPaciente(int IdPaciente)
        {
            var detallesPacienteSinformato = await _medicoDA.ObtenerDetallesPaciente(IdPaciente);
            if (detallesPacienteSinformato == null)
                return null;
            return _formatoHelper.DarFormatoDetallesPaciente(detallesPacienteSinformato);
        }

        public async Task<Medico_EnfermedadDiagnostico> ObtenerEnfermedadDiagnostico(int id_EnferDiagnostico)
        {
            var enfermedadDiagnosticoSinformato = await _medicoDA.ObtenerEnfermedadDiagnostico(id_EnferDiagnostico);
            if (enfermedadDiagnosticoSinformato == null)
                return null;
            return _formatoHelper.DarFormatoEnfermedadDiagnostico(enfermedadDiagnosticoSinformato);
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

        public async Task<Medico_Medicamento> ObtenerDetalleMedicamento(int id_Medicamento)
        {
            var medicamentoSinformato = await _medicoDA.ObtenerDetalleMedicamento(id_Medicamento);
            if (medicamentoSinformato == null)
                return null;
            return _formatoHelper.DarFormatoDetalleMedicamento(medicamentoSinformato);
        }

        public async Task<IEnumerable<PacienteMedicamentoBD>> ObtenerListaPacienteMedicamento(int id_Medicacion_Paciente)
        {
            var PacienteMedicamentoSinFormato = await _medicoDA.ObtenerListaPacienteMedicamento(id_Medicacion_Paciente);
            if (!PacienteMedicamentoSinFormato.Any())
                return PacienteMedicamentoSinFormato;
            return _formatoHelper.DarFormatoListaPacienteMedicamento(PacienteMedicamentoSinFormato);
        }

        public async Task<int> EditarDiagnosticoPaciente(int id_EnferDiagnostico, Medico_EnfermedadDiagnostico enfermedadDiagnostico)
        {
            var resultado = await _medicoDA.EditarDiagnosticoPaciente(id_EnferDiagnostico, enfermedadDiagnostico);
            return resultado;
        }

    }
}
