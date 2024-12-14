using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.DA
{
    public interface IPacienteDA
    {
        Task<Paciente_DetallesMedicacion> PacienteObtenerDetallesMedicacion(int IdMedicacionPaciente);  //cambiado el SP y probado por eliecer
        Task<IEnumerable<PacientePadecimientosBD>> PacienteObtenerListaPadecimientos(Guid IdPaciente); // agregado y probado por eliecer
        Task<Paciente_DetallesPadecimiento> ObtenerPacienteDetallesPadecimiento(int idEnfermedadDiagnostico, int idCita); //cambiado el SP y probado por eliecer

        Task<IEnumerable<CitaDetallesBD>> ObtenerCitasPendientesPorPaciente(int idPaciente);
        Task<IEnumerable<CitaDetallesBD>> ObtenerCitasAtendidasPorPaciente(int idPaciente);

        Task<int> EliminarCitaPendiente(int idCita); // agregado y probado por eliecer, se puede usar tanto para medico y paciente

        Task<CitaMapping> ObtenerCita(int IdCita);  // agregadopor eliecer

        Task<Guid> EliminarPerfil(Guid idPersona); // agregado y probado por eliecer, se puede usar tanto para medico y paciente en el API

        Task<Persona> ObtenerPersona(Guid idPersona); // agregadopor eliecer
    }
}
