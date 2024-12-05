using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.Flujo
{
    public interface IPacienteFlujo
    {
        Task<Paciente_DetallesMedicacion> PacienteObtenerDetallesMedicacion(int IdMedicacionPaciente); //cambiado el SP y probado por eliecer

        Task<Paciente_DetallesPadecimiento> ObtenerPacienteDetallesPadecimiento(int idEnfermedadDiagnostico, int idCita); //cambiado el SP y probado por eliecer

        Task<IEnumerable<CitaDetallesBD>> ObtenerCitasPendientesPorPaciente(int idPaciente);

        Task<IEnumerable<CitaDetallesBD>> ObtenerCitasAtendidasPorPaciente(int idPaciente);
    }
}
