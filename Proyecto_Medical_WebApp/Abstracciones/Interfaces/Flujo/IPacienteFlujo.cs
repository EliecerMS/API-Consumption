using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.Flujo
{
    public interface IPacienteFlujo
    {
        Task<PacienteDetallesMedicacion> PacienteObtenerDetallesMedicacion(int IdMedicacionPaciente);

        Task<PacienteDetallesPadecimiento> ObtenerPacienteDetallesPadecimiento(int idPaciente, int idEnfermedadDiagnostico, int idCita, int idMedico);
    }
}
