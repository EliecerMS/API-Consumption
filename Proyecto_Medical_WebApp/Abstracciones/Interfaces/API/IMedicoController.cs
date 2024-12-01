using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Abstracciones.Interfaces.API
{
    public interface IMedicoController
    {
        Task<IActionResult> ObtenerPacientesMedico(int medicoId);

        Task<IActionResult> ObtenerDetallesPacientePorId(int idPaciente);

        Task<IActionResult> ObtenerPacientesYPadecimientos(int medicoId);

        Task<IActionResult> ObtenerEnfermedadDiagnostico(int id_EnferDiagnostico);
        Task<IActionResult> ObtenerMedicamento(int id_Medicamento);
        Task<IActionResult> ObtenerPacienteMedicamento(int id_Medicacion_Paciente);

        Task<IActionResult> EditarPesoAltura(int IdPaciente, Medico_PesoAltura pacienteInformacion);

    }
}
