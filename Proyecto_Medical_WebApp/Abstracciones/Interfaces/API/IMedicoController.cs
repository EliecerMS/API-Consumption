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
        Task<IActionResult> ObtenerMedicamento(int id_Medicamento, Guid id_Paciente);
        Task<IActionResult> ObtenerPacienteMedicamento(Guid id_Medico);

        Task<IActionResult> EditarPesoAltura(Guid IdPaciente, Medico_PesoAltura pacienteInformacion);


        Task<IActionResult> EditarDiagnostico(int id_EnferDiagnostico, Medico_EnfermedadDiagnostico enfermedadDiagnostico);

        Task<IActionResult> AgregarEnfermedadDiagnostico(Medico_RegistroEnfDiagnostico diagnostico);
        Task<IActionResult> AgregarMedicacionPaciente(Medico_MedPaciente medicacion);
        Task<IActionResult> ObtenerListaDoctores();
        Task<IActionResult> CrearCita(Medico_CrearCita nuevaCita);


        Task<IActionResult> EliminarMedicacionPaciente(int idMedicacionPaciente); // agregado y probado por eliecer

        Task<IActionResult> EliminarPadecimientoPaciente(int idEnferDiagnostico); // agregado y probado por eliecer

        Task<IActionResult> CrearEnfermedadDiagnostico(EnfermedaDiagnosticoMapping enfermedadDiagnostico); // agregado y probado por eliecer

        Task<IActionResult> CrearPacienteMedicacion(MedicacionPacienteMapping medicacionPaciente);// agregado y probado por eliecer

        Task<IActionResult> ObtenerPadecimientoPaciente(int idEnferDiagnostico); // agregado y probado por eliecer

        Task<IActionResult> ObtenerMedicacionPaciente(int idMedicacionPaciente); // agregado y probado por eliecer

    }
}
