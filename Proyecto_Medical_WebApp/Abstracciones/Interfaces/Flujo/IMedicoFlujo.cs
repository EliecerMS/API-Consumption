using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.Flujo
{
    public interface IMedicoFlujo
    {
        Task<IEnumerable<PacientesMedicoBD>> ObtenerListaPacientes(int medicoId);

        Task<DetallesPaciente> ObtenerDetallesPaciente(int IdPaciente);

        Task<IEnumerable<PacientesPadecimientosBD>> ObtenerListaPacientesYPadecimientos(int medicoId);
    }
}
