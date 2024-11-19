using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalAPIController : ControllerBase, IMedicoController
    {
        private IMedicoFlujo _medicoFlujo;

        private ILogger<MedicalAPIController> _logger;

        public MedicalAPIController(IMedicoFlujo medicoFlujo, ILogger<MedicalAPIController> logger)
        {
            _medicoFlujo = medicoFlujo;
            _logger = logger;
        }
        [HttpGet("ObtenerDetallesPacientePorId/{idPaciente}")]
        public async Task<IActionResult> ObtenerDetallesPacientePorId(int idPaciente)
        {
            _logger.LogInformation("Obteniendo detalles del paciente");
            var resultado = await _medicoFlujo.ObtenerDetallesPaciente(idPaciente);
            if (resultado == null)
                return NotFound();
            return Ok(resultado);
        }

        [HttpGet("ObtenerListaPacientes/{idMedico}")]
        public async Task<IActionResult> ObtenerPacientesMedico(int idMedico)
        {
            _logger.LogInformation("Obteniendo pacientes");
            var resultado = await _medicoFlujo.ObtenerListaPacientes(idMedico);
            if (!resultado.Any())
                return NoContent();
            return Ok(resultado);
        }

        [HttpGet("ObtenerListaPacientesYPadecimientos/{idMedico}")]
        public async Task<IActionResult> ObtenerPacientesYPadecimientos(int idMedico)
        {
            _logger.LogInformation("Obteniendo pacientes y padecimientos");
            var resultado = await _medicoFlujo.ObtenerListaPacientesYPadecimientos(idMedico);
            if (!resultado.Any())
                return NoContent();
            return Ok(resultado);
        }
    }
}
