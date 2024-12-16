using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.Flujo
{
    public interface IPacienteFlujo
    {
        Task<Paciente_DetallesMedicacion> PacienteObtenerDetallesMedicacion(int IdMedicacionPaciente); //cambiado el SP y probado por eliecer
        Task<IEnumerable<PacientePadecimientosBD>> PacienteObtenerListaPadecimientos(Guid IdPaciente); // agregado y probado por eliecer
        Task<Paciente_DetallesPadecimiento> ObtenerPacienteDetallesPadecimiento(int idEnfermedadDiagnostico, int idCita); //cambiado el SP y probado por eliecer

        Task<IEnumerable<CitaDetallesBD>> ObtenerCitasPendientesPorPaciente(int idPaciente);

        Task<IEnumerable<CitaDetallesBD>> ObtenerCitasAtendidasPorPaciente(int idPaciente);

        Task<int> EliminarCitaPendiente(int idCita); // agregado y probado por eliecer
        Task<CitaMapping> ObtenerCita(int IdCita);  // agregadopor eliecer
        Task<Guid> EliminarPerfil(Guid idPersona); // agregadopor eliecer

        Task<Persona> ObtenerPersona(Guid idPersona); // agregadopor eliecer

        Task<Guid> CrearPerfil(Persona perfil);//agregado por eliecer, funciona para crear un perfil
    }
}
