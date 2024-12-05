using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Abstracciones.Interfaces.API
{
    public interface IMedicoController
    {
        Task<IActionResult> ObtenerPacientesMedico(Guid medicoId); //cambiado el SP y probado por eliecer

        Task<IActionResult> ObtenerDetallesPacientePorId(Guid idPaciente); //cambiado el SP y probado por eliecer

        Task<IActionResult> ObtenerPacientesYPadecimientos(Guid medicoId); //cambiado el SP y probado por eliecer

        Task<IActionResult> ObtenerEnfermedadDiagnostico(int id_EnferDiagnostico);
        Task<IActionResult> ObtenerMedicamento(int id_Medicamento, int id_Paciente);
        Task<IActionResult> ObtenerPacienteMedicamento(int id_Medico);

        Task<IActionResult> EditarPesoAltura(int IdPaciente, Medico_PesoAltura pacienteInformacion);


        Task<IActionResult> EditarDiagnostico(int id_EnferDiagnostico, Medico_EnfermedadDiagnostico enfermedadDiagnostico);

    }
}
