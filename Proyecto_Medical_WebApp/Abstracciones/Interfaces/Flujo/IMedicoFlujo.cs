using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.Flujo
{
    public interface IMedicoFlujo
    {
        Task<IEnumerable<PacientesMedicoBD>> ObtenerListaPacientes(Guid medicoId); //cambiado el SP y probado por eliecer

        Task<Medico_DetallesPaciente> ObtenerDetallesPaciente(Guid IdPaciente); //cambiado el SP y probado por eliecer

        Task<IEnumerable<PacientesPadecimientosBD>> ObtenerListaPacientesYPadecimientos(Guid medicoId); //cambiado el SP y probado por eliecer

        Task<Medico_EnfermedadDiagnostico> ObtenerEnfermedadDiagnostico(int id_EnferDiagnostico);
        Task<Medico_Medicamento> ObtenerDetalleMedicamento(int id_Medicamento, Guid id_Paciente);
        Task<IEnumerable<PacienteMedicamentoBD>> ObtenerListaPacienteMedicamento(Guid id_Medicacion_Paciente);
        Task<int> EditarPesoAlturaPaciente(int IdPaciente, Medico_PesoAltura pacienteInformacion);

        Task<int> EditarDiagnosticoPaciente(int id_EnferDiagnostico, Medico_EnfermedadDiagnostico enfermedadDiagnostico);

        Task<IEnumerable<CitaDetallesBD>> ObtenerCitasPendientesPorMedico(int idMedico);
        Task<IEnumerable<CitaDetallesBD>> ObtenerCitasAtendidasPorMedico(int idMedico);
        Task<int> EditarCita(int idCita, Medico_CitaEdicion citaEdicion);
        Task<IEnumerable<MedicamentoBD>> ObtenerListaMedicamentos();
        Task<IEnumerable<MedicacionDetalladaBD>> ObtenerMedicacionesDetalladas();
    }
}
