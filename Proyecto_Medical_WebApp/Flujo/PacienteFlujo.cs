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

        public async Task<Paciente_DetallesPadecimiento> ObtenerPacienteDetallesPadecimiento(int idEnfermedadDiagnostico, int idCita) //cambiado el SP y probado por eliecer
        {
            var detallesPadecimientoSinformato = await _pacienteDA.ObtenerPacienteDetallesPadecimiento(idEnfermedadDiagnostico, idCita);
            if (detallesPadecimientoSinformato == null)
                return null;
            return _formatoHelper.DarFomartoPacienteDetallesPadecimiento(detallesPadecimientoSinformato);
        }

        public async Task<Paciente_DetallesMedicacion> PacienteObtenerDetallesMedicacion(int IdMedicacionPaciente) //cambiado el SP y probado por eliecer

        {
            var detallesMedicacionSinformato = await _pacienteDA.PacienteObtenerDetallesMedicacion(IdMedicacionPaciente);
            if (detallesMedicacionSinformato == null)
                return null;
            return _formatoHelper.DarFomartoPacienteDetallesMedicacion(detallesMedicacionSinformato);
        }

        public async Task<IEnumerable<PacientePadecimientosBD>> PacienteObtenerListaPadecimientos(Guid IdPaciente) // agregado y probado por eliecer
        {
            var padecimientosSinFormato = await _pacienteDA.PacienteObtenerListaPadecimientos(IdPaciente);
            if (!padecimientosSinFormato.Any())
                return padecimientosSinFormato;
            return _formatoHelper.DarFormatoListaPadecimientosPaciente(padecimientosSinFormato);
        }

        public async Task<int> EliminarCitaPendiente(int idCita) // agregado y probado por eliecer
        {
            var resultado = await _pacienteDA.EliminarCitaPendiente(idCita);
            return resultado;
        }

        public async Task<CitaMapping> ObtenerCita(int IdCita) // agregado por eliecer
        {
            var citaResultado = await _pacienteDA.ObtenerCita(IdCita);
            if (citaResultado == null)
                return null;
            return citaResultado;
        }

        public async Task<Guid> EliminarPerfil(Guid idPersona) // agregado por eliecer
        {
            var resultado = await _pacienteDA.EliminarPerfil(idPersona);
            return resultado;
        }

        public async Task<Persona> ObtenerPersona(Guid idPersona) // agregado por eliecer
        {
            var personaResultado = await _pacienteDA.ObtenerPersona(idPersona);
            if (personaResultado == null)
                return null;
            return personaResultado;
        }

        public async Task<Guid> CrearPerfil(Persona perfil)
        {
            var resultado = await _pacienteDA.CrearPerfil(perfil);
            return resultado;
        }
    }
}
