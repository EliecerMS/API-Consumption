using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.DA
{
    public interface IPacienteDA
    {
        Task<Paciente_DetallesMedicacion> PacienteObtenerDetallesMedicacion(int IdMedicacionPaciente);

        Task<Paciente_DetallesPadecimiento> ObtenerPacienteDetallesPadecimiento(int idPaciente, int idEnfermedadDiagnostico, int idCita, int idMedico);

        Task<IEnumerable<CitaDetallesBD>> ObtenerCitasPendientesPorPaciente(int idPaciente);
        Task<IEnumerable<CitaDetallesBD>> ObtenerCitasAtendidasPorPaciente(int idPaciente);
    }
}
