using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.Flujo
{
    public interface IMedicoFlujo
    {
        Task<IEnumerable<PacientesMedicoBD>> ObtenerListaPacientes(int medicoId);

        Task<Medico_DetallesPaciente> ObtenerDetallesPaciente(int IdPaciente);

        Task<IEnumerable<PacientesPadecimientosBD>> ObtenerListaPacientesYPadecimientos(int medicoId);

        Task<Medico_EnfermedadDiagnostico> ObtenerEnfermedadDiagnostico(int id_EnferDiagnostico);
        Task<Medico_Medicamento> ObtenerDetalleMedicamento(int id_Medicamento);
        Task<IEnumerable<PacienteMedicamentoBD>> ObtenerListaPacienteMedicamento(int id_Medicacion_Paciente);
        Task<int> EditarPesoAlturaPaciente(int IdPaciente, Medico_PesoAltura pacienteInformacion);
    }
}
