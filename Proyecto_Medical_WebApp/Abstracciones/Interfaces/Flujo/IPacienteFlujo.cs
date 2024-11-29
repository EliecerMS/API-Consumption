using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.Flujo
{
    public interface IPacienteFlujo
    {
        Task<Paciente_DetallesMedicacion> PacienteObtenerDetallesMedicacion(int IdMedicacionPaciente);

        Task<Paciente_DetallesPadecimiento> ObtenerPacienteDetallesPadecimiento(int idPaciente, int idEnfermedadDiagnostico, int idCita, int idMedico);
    }
}
