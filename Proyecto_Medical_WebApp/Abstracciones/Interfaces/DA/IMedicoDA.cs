using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.DA
{
    public interface IMedicoDA
    {
        Task<IEnumerable<PacientesMedicoBD>> ObtenerListaPacientes(int medicoId);

        Task<Medico_DetallesPaciente> ObtenerDetallesPaciente(int IdPaciente);

        Task<IEnumerable<PacientesPadecimientosBD>> ObtenerListaPacientesYPadecimientos(int medicoId);

        Task<EnfermedadDiagnosticoBD> ObtenerEnfermedadDiagnostico(int Id_EnfermedadDiagnostico);
        Task<MedicamentoBD> ObtenerDetalleMedicamento(int Id_Medicamento);

    }
}
