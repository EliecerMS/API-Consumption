using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.Flujo
{
    public interface IMedicoFlujo
    {
        Task<IEnumerable<PacientesMedicoBD>> ObtenerListaPacientes(int medicoId);

        Task<Medico_DetallesPaciente> ObtenerDetallesPaciente(int IdPaciente);

        Task<IEnumerable<PacientesPadecimientosBD>> ObtenerListaPacientesYPadecimientos(int medicoId);

        Task<Medico_EnfermedadDiagnostico> ObtenerEnfermedadDiagnostico(int Id_EnfermedadDiagnostico);
        Task<Medico_Medicamento> ObtenerMedicamento(int Id_Medicamento);
    }
}
