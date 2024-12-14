using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.DA
{
    public interface IMedicoDA
    {
        Task<IEnumerable<PacientesMedicoBD>> ObtenerListaPacientes(Guid medicoId); //cambiado el SP y probado por eliecer

        Task<Medico_DetallesPaciente> ObtenerDetallesPaciente(Guid IdPaciente); //cambiado el SP y probado por eliecer

        Task<IEnumerable<PacientesPadecimientosBD>> ObtenerListaPacientesYPadecimientos(Guid medicoId); //cambiado el SP y probado por eliecer

        Task<EnfermedadDiagnosticoBD> ObtenerEnfermedadDiagnostico(int id_EnferDiagnostico);
        Task<MedicamentoBD> ObtenerDetalleMedicamento(int id_Medicamento, Guid id_Paciente);

        Task<IEnumerable<PacienteMedicamentoBD>> ObtenerListaPacienteMedicamento(Guid id_Medicacion_Paciente);

        Task<int> EditarPesoAlturaPaciente(int IdPaciente, Medico_PesoAltura pacienteInformacion);


        Task<int> EditarDiagnosticoPaciente(int id_EnferDiagnostico, Medico_EnfermedadDiagnostico enfermedadDiagnostico);

        Task<IEnumerable<CitaDetallesBD>> ObtenerCitasPendientesPorMedico(int idMedico);
        Task<IEnumerable<CitaDetallesBD>> ObtenerCitasAtendidasPorMedico(int idMedico);
        Task<int> EditarCita(int idCita, Medico_CitaEdicion citaEdicion);
        Task<IEnumerable<MedicamentoBD>> ObtenerListaMedicamentos();
        //comentario de ejemplo
        Task<IEnumerable<MedicacionDetalladaBD>> ObtenerMedicacionesDetalladas();
    }
}
