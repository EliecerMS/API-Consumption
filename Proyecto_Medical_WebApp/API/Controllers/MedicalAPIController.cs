using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalAPIController : ControllerBase, IMedicoController, IPacienteController
    {
        private IMedicoFlujo _medicoFlujo;
        private IPacienteFlujo _pacienteFlujo;

        private ILogger<MedicalAPIController> _logger;

        public MedicalAPIController(IMedicoFlujo medicoFlujo, IPacienteFlujo pacienteFlujo, ILogger<MedicalAPIController> logger)
        {
            _medicoFlujo = medicoFlujo;
            _pacienteFlujo = pacienteFlujo;
            _logger = logger;
        }

        [HttpPut("EditarPesoAlturaPaciente/{IdPaciente}")]
        public async Task<IActionResult> EditarPesoAltura([FromRoute] int IdPaciente, [FromBody] Medico_PesoAltura pacienteInformacion)
        {
            var resultado = await _medicoFlujo.EditarPesoAlturaPaciente(IdPaciente, pacienteInformacion);
            if (resultado == 0)
                return BadRequest("El paciente a editar no existe");
            return Ok(resultado);
        }

        [HttpGet("Medico_ObtenerDetallesPacientePorId/{idPaciente}")]
        public async Task<IActionResult> ObtenerDetallesPacientePorId(int idPaciente)
        {
            _logger.LogInformation("Obteniendo detalles del paciente");
            var resultado = await _medicoFlujo.ObtenerDetallesPaciente(idPaciente);
            if (resultado == null)
                return NotFound();
            return Ok(resultado);
        }


        [HttpGet("Medico_ObtenerEnfermedadDiagnostico/{id_EnferDiagnostico}")]
        public async Task<IActionResult> ObtenerEnfermedadDiagnostico(int id_EnferDiagnostico)
        {
            _logger.LogInformation("Obteniendo Enfermedades con su Diagnostico");
            var resultado = await _medicoFlujo.ObtenerEnfermedadDiagnostico(id_EnferDiagnostico);
            if (resultado == null)
                return NotFound();
            return Ok(resultado);
        }

        [HttpGet("Medico_ObtenerMedicamento/{id_Medicamento}")]
        public async Task<IActionResult> ObtenerMedicamento(int id_Medicamento)
        {
            _logger.LogInformation("Obteniendo medicamentos");
            var resultado = await _medicoFlujo.ObtenerDetalleMedicamento(id_Medicamento);
            if (resultado == null)
                return NotFound();
            return Ok(resultado);
        }



        [HttpGet("Paciente_ObtenerDetallesMedicacionPorIdMedicacion/{idMedicacionPaciente}")]
        public async Task<IActionResult> ObtenerPacienteDetallesMedicacion(int idMedicacionPaciente)
        {
            _logger.LogInformation("Obteniendo detalles del medicamento");
            var resultado = await _pacienteFlujo.PacienteObtenerDetallesMedicacion(idMedicacionPaciente);
            if (resultado == null)
                return NotFound();
            return Ok(resultado);
        }

        [HttpGet("Paciente_ObtenerDetallesPadecimientoPorIds/{idPaciente}/{idEnfermedadDiagnostico}/{idCita}/{idMedico}/")]
        public async Task<IActionResult> ObtenerPacienteDetallesPadecimiento(int idPaciente, int idEnfermedadDiagnostico, int idCita, int idMedico)
        {
            _logger.LogInformation("Obteniendo detalles del padecimiento");
            var resultado = await _pacienteFlujo.ObtenerPacienteDetallesPadecimiento(idPaciente, idEnfermedadDiagnostico, idCita, idMedico);
            if (resultado == null)
                return NotFound();
            return Ok(resultado);
        }

        

        [HttpGet("Medico_ObtenerListaPacientes/{idMedico}")]
        public async Task<IActionResult> ObtenerPacientesMedico(int idMedico)
        {
            _logger.LogInformation("Obteniendo pacientes");
            var resultado = await _medicoFlujo.ObtenerListaPacientes(idMedico);
            if (!resultado.Any())
                return NoContent();
            return Ok(resultado);
        }

        [HttpGet("Medico_ObtenerListaPacientesYPadecimientos/{idMedico}")]
        public async Task<IActionResult> ObtenerPacientesYPadecimientos(int idMedico)
        {
            _logger.LogInformation("Obteniendo pacientes y padecimientos");
            var resultado = await _medicoFlujo.ObtenerListaPacientesYPadecimientos(idMedico);
            if (!resultado.Any())
                return NoContent();
            return Ok(resultado);
        }
        [HttpGet("Medico_ObtenerListaPacienteMedicamento/{id_Medicacion_Paciente}")]
        public async Task<IActionResult> ObtenerPacienteMedicamento(int id_Medicacion_Paciente)
        {
            _logger.LogInformation("Obteniendo pacientes y medicamentos");
            var resultado = await _medicoFlujo.ObtenerListaPacienteMedicamento(id_Medicacion_Paciente);
            if (!resultado.Any())
                return NoContent();
            return Ok(resultado);
        }

    }
}
