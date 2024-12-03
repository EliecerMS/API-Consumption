using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;

namespace Flujo
{
    public class PacienteFlujo : IPacienteFlujo
    {
        private IPacienteDA _pacienteDA;
        private IFormatoHelper _formatoHelper;

        public PacienteFlujo(IPacienteDA pacienteDA, IFormatoHelper formatoHelper)
        {
            _pacienteDA = pacienteDA;
            _formatoHelper = formatoHelper;
        }

        public Task<IEnumerable<CitaDetallesBD>> ObtenerCitasAtendidasPorPaciente(int idPaciente)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CitaDetallesBD>> ObtenerCitasPendientesPorPaciente(int idPaciente)
        {
            throw new NotImplementedException();
        }

        public async Task<Paciente_DetallesPadecimiento> ObtenerPacienteDetallesPadecimiento(int idPaciente, int idEnfermedadDiagnostico, int idCita, int idMedico)
        {
            var detallesPadecimientoSinformato = await _pacienteDA.ObtenerPacienteDetallesPadecimiento(idPaciente, idEnfermedadDiagnostico, idCita, idMedico);
            if (detallesPadecimientoSinformato == null)
                return null;
            return _formatoHelper.DarFomartoPacienteDetallesPadecimiento(detallesPadecimientoSinformato);
        }

        public async Task<Paciente_DetallesMedicacion> PacienteObtenerDetallesMedicacion(int IdMedicacionPaciente)
        {
            var detallesMedicacionSinformato = await _pacienteDA.PacienteObtenerDetallesMedicacion(IdMedicacionPaciente);
            if (detallesMedicacionSinformato == null)
                return null;
            return _formatoHelper.DarFomartoPacienteDetallesMedicacion(detallesMedicacionSinformato);
        }
    }
}
