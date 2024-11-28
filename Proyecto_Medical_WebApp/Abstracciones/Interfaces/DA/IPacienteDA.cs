using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.DA
{
    public interface IPacienteDA
    {
        Task<PacienteDetallesMedicacion> PacienteObtenerDetallesMedicacion(int IdMedicacionPaciente);

        Task<PacienteDetallesPadecimiento> ObtenerPacienteDetallesPadecimiento(int idPaciente, int idEnfermedadDiagnostico, int idCita, int idMedico);
    }
}
