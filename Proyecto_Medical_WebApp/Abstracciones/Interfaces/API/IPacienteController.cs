using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Abstracciones.Interfaces.API
{
    public interface IPacienteController
    {
        Task<IActionResult> ObtenerPacienteDetallesMedicacion(int idMedicacionPaciente); //cambiado el SP y probado por eliecer

        Task<IActionResult> ObtenerPacienteDetallesPadecimiento(int idEnfermedadDiagnostico, int idCita); //cambiado el SP y probado por eliecer

        Task<IActionResult> ObtenerPacienteListaPadecimientos(Guid idPaciente); // agregado y probado por eliecer

        Task<IActionResult> EliminarCitaPendiente(int idCita); // agregado y probado por eliecer

        Task<IActionResult> ObtenerCita(int idCita); // agregado y probado por eliecer

        Task<IActionResult> EliminarPerfil(Guid idPersona); // agregado y probado por eliecer

        Task<IActionResult> ObtenerPersona(Guid idPersona); // agregado y probado por eliecer

        Task<IActionResult> CrearPerfil(Persona perfil);// agregado por eliecer

    }
}
