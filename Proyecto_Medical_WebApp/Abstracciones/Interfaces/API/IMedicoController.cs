using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Abstracciones.Interfaces.API
{
    public interface IMedicoController
    {
        Task<IActionResult> ObtenerPacientesMedico(int medicoId);

        Task<IActionResult> ObtenerDetallesPacientePorId(int idPaciente);

        Task<IActionResult> ObtenerPacientesYPadecimientos(int medicoId);

        Task<IActionResult> ObtenerEnfermedadDiagnostico(int Id_EnfermedadDiagnostico);
        Task<IActionResult> ObtenerMedicamento(int Id_Medicamento);

        Task<IActionResult> EditarPesoAltura(int IdPaciente, Medico_PesoAltura pacienteInformacion);

    }
}
