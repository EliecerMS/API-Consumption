using Microsoft.AspNetCore.Mvc;

namespace Abstracciones.Interfaces.API
{
    public interface IPacienteController
    {
        Task<IActionResult> ObtenerPacienteDetallesMedicacion(int idMedicacionPaciente); //cambiado el SP y probado por eliecer

        Task<IActionResult> ObtenerPacienteDetallesPadecimiento(int idEnfermedadDiagnostico, int idCita); //cambiado el SP y probado por eliecer
    }
}
