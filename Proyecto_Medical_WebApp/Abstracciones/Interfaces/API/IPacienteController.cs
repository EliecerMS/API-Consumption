using Microsoft.AspNetCore.Mvc;

namespace Abstracciones.Interfaces.API
{
    public interface IPacienteController
    {
        Task<IActionResult> ObtenerPacienteDetallesMedicacion(int idMedicacionPaciente);

        Task<IActionResult> ObtenerPacienteDetallesPadecimiento(int idPaciente, int idEnfermedadDiagnostico, int idCita, int idMedico);
    }
}
