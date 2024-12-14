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
        public async Task<IActionResult> ObtenerDetallesPacientePorId([FromRoute] Guid idPaciente) //cambiado el SP y probado por eliecer
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
            try
            {
                _logger.LogInformation("Obteniendo Enfermedades con su Diagnostico");
                var resultado = await _medicoFlujo.ObtenerEnfermedadDiagnostico(id_EnferDiagnostico);
                if (resultado == null)
                    return NotFound("No se encontraron datos para el diagnóstico solicitado.");
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener el diagnóstico: {ex.Message}", ex);
                return StatusCode(500, "Ocurrió un error interno al procesar la solicitud.");
            }
        }

        [HttpGet("Medico_ObtenerMedicamento/{id_Medicamento}/{id_Paciente}")]
        public async Task<IActionResult> ObtenerMedicamento(int id_Medicamento, Guid id_Paciente)
        {
            _logger.LogInformation("Obteniendo medicamentos");
            var resultado = await _medicoFlujo.ObtenerDetalleMedicamento(id_Medicamento, id_Paciente);
            if (resultado == null)
                return NotFound();
            return Ok(resultado);
        }



        [HttpGet("Paciente_ObtenerDetallesMedicacionPorIdMedicacion/{idMedicacionPaciente}")]
        public async Task<IActionResult> ObtenerPacienteDetallesMedicacion([FromRoute] int idMedicacionPaciente)
        {
            _logger.LogInformation("Obteniendo detalles del medicamento");
            var resultado = await _pacienteFlujo.PacienteObtenerDetallesMedicacion(idMedicacionPaciente);
            if (resultado == null)
                return NotFound();
            return Ok(resultado);
        }

        [HttpGet("Paciente_ObtenerDetallesPadecimientoPorIds/{idEnfermedadDiagnostico}/{idCita}/")] //cambiado el SP y probado por eliecer
        public async Task<IActionResult> ObtenerPacienteDetallesPadecimiento(int idEnfermedadDiagnostico, int idCita)
        {
            _logger.LogInformation("Obteniendo detalles del padecimiento");
            var resultado = await _pacienteFlujo.ObtenerPacienteDetallesPadecimiento(idEnfermedadDiagnostico, idCita);
            if (resultado == null)
                return NotFound();
            return Ok(resultado);
        }



        [HttpGet("Medico_ObtenerListaPacientes/{idMedico}")]
        public async Task<IActionResult> ObtenerPacientesMedico([FromRoute] Guid idMedico) //cambiado el SP y probado por eliecer
        {
            _logger.LogInformation("Obteniendo pacientes");
            var resultado = await _medicoFlujo.ObtenerListaPacientes(idMedico);
            if (!resultado.Any())
                return NoContent();
            return Ok(resultado);
        }

        [HttpGet("Medico_ObtenerListaPacientesYPadecimientos/{idMedico}")]
        public async Task<IActionResult> ObtenerPacientesYPadecimientos([FromRoute] Guid idMedico) //cambiado el SP y probado por eliecer
        {
            _logger.LogInformation("Obteniendo pacientes y padecimientos");
            var resultado = await _medicoFlujo.ObtenerListaPacientesYPadecimientos(idMedico);
            if (!resultado.Any())
                return NoContent();
            return Ok(resultado);
        }

        [HttpGet("Medico_ObtenerListaPacienteMedicamento/{id_Medico}")]
        public async Task<IActionResult> ObtenerPacienteMedicamento([FromRoute] Guid id_Medico)
        {
            try
            {
                _logger.LogInformation($"Obteniendo pacientes y medicamentos para el médico con ID: {id_Medico}");
                var resultado = await _medicoFlujo.ObtenerListaPacienteMedicamento(id_Medico);
                if (!resultado.Any())
                    return NoContent();
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener pacientes y medicamentos: {ex.Message}", ex);
                return StatusCode(500, "Error interno en el servidor");
            }
        }


        [HttpPut("EditarDiagnostico/{id_EnferDiagnostico}")]
        public async Task<IActionResult> EditarDiagnostico([FromRoute] int id_EnferDiagnostico, [FromBody] Medico_EnfermedadDiagnostico enfermedadDiagnostico)
        {
            try
            {
                if (enfermedadDiagnostico == null)
                    return BadRequest("Los datos del diagnóstico son inválidos.");

                var resultado = await _medicoFlujo.EditarDiagnosticoPaciente(id_EnferDiagnostico, enfermedadDiagnostico);
                if (resultado == 0)
                    return NotFound("El diagnóstico del paciente no existe o no fue actualizado.");

                return Ok("Diagnóstico actualizado correctamente.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al editar el diagnóstico: {ex.Message}", ex);
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpGet("Medico_ObtenerCitasPendientes/{idMedico}")]
        public async Task<IActionResult> ObtenerCitasPendientesPorMedico(int idMedico)
        {
            try
            {
                _logger.LogInformation($"Obteniendo citas pendientes para el médico con ID: {idMedico}");
                var resultado = await _medicoFlujo.ObtenerCitasPendientesPorMedico(idMedico);
                if (!resultado.Any())
                    return NoContent();
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener citas pendientes: {ex.Message}", ex);
                return StatusCode(500, "Error interno en el servidor.");
            }
        }

        [HttpGet("Medico_ObtenerCitasAtendidas/{idMedico}")]
        public async Task<IActionResult> ObtenerCitasAtendidasPorMedico(int idMedico)
        {
            try
            {
                _logger.LogInformation($"Obteniendo citas atendidas para el médico con ID: {idMedico}");
                var resultado = await _medicoFlujo.ObtenerCitasAtendidasPorMedico(idMedico);
                if (!resultado.Any())
                    return NoContent();
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener citas atendidas: {ex.Message}", ex);
                return StatusCode(500, "Error interno en el servidor.");
            }
        }

        [HttpPut("EditarCita/{idCita}")]
        public async Task<IActionResult> EditarCita(int idCita, [FromBody] Medico_CitaEdicion citaEdicion)
        {
            try
            {
                if (citaEdicion == null)
                    return BadRequest("Los datos de la cita son inválidos.");

                var resultado = await _medicoFlujo.EditarCita(idCita, citaEdicion);
                if (resultado == 0)
                    return NotFound("La cita no existe o no fue actualizada.");

                return Ok("Cita actualizada correctamente.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al editar la cita: {ex.Message}", ex);
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpGet("Paciente_ObtenerCitasPendientes/{idPaciente}")]
        public async Task<IActionResult> ObtenerCitasPendientesPorPaciente(int idPaciente)
        {
            try
            {
                _logger.LogInformation($"Obteniendo citas pendientes para el paciente con ID: {idPaciente}");
                var resultado = await _pacienteFlujo.ObtenerCitasPendientesPorPaciente(idPaciente);
                if (!resultado.Any())
                    return NoContent();
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener citas pendientes: {ex.Message}", ex);
                return StatusCode(500, "Error interno en el servidor.");
            }
        }

        [HttpGet("Paciente_ObtenerCitasAtendidas/{idPaciente}")]
        public async Task<IActionResult> ObtenerCitasAtendidasPorPaciente(int idPaciente)
        {
            try
            {
                _logger.LogInformation($"Obteniendo citas atendidas para el paciente con ID: {idPaciente}");
                var resultado = await _pacienteFlujo.ObtenerCitasAtendidasPorPaciente(idPaciente);
                if (!resultado.Any())
                    return NoContent();
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener citas atendidas: {ex.Message}", ex);
                return StatusCode(500, "Error interno en el servidor.");
            }
        }

        [HttpGet("ObtenerListaMedicamentos")]
        public async Task<IActionResult> ObtenerListaMedicamentos()
        {
            try
            {
                _logger.LogInformation("Obteniendo lista de medicamentos.");
                var resultado = await _medicoFlujo.ObtenerListaMedicamentos();
                if (!resultado.Any())
                    return NoContent();
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener medicamentos: {ex.Message}", ex);
                return StatusCode(500, "Error interno en el servidor.");
            }
        }

        [HttpGet("ObtenerMedicacionesDetalladas")]
        public async Task<IActionResult> ObtenerMedicacionesDetalladas()
        {
            try
            {
                _logger.LogInformation("Obteniendo lista detallada de medicaciones.");
                var resultado = await _medicoFlujo.ObtenerMedicacionesDetalladas();
                if (!resultado.Any())
                    return NoContent();
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener medicaciones detalladas: {ex.Message}", ex);
                return StatusCode(500, "Error interno en el servidor.");
            }
        }

        [HttpGet("Paciente_ObtenerListaPadecimientos/{idPaciente}")]
        public async Task<IActionResult> ObtenerPacienteListaPadecimientos([FromRoute] Guid idPaciente) // agregado y probado por eliecer
        {
            _logger.LogInformation("Obteniendo padecimientos");
            var resultado = await _pacienteFlujo.PacienteObtenerListaPadecimientos(idPaciente);
            if (!resultado.Any())
                return NoContent();
            return Ok(resultado);
        }

        [HttpDelete("Paciente_Medico-EliminarCitaPendiente/{idCita}")]
        public async Task<IActionResult> EliminarCitaPendiente([FromRoute] int idCita) // agregado y probado por eliecer, se puede usar tanto para medico y paciente
        {
            var resultado = await _pacienteFlujo.EliminarCitaPendiente(idCita);
            if (resultado == 0)
                return BadRequest("Lo cita eliminar no exite");
            return NoContent();
        }

        [HttpDelete("Medico_EliminarMedicacionPaciente/{idMedicacionPaciente}")]
        public async Task<IActionResult> EliminarMedicacionPaciente([FromRoute] int idMedicacionPaciente) // agregado y probado por eliecer
        {
            var resultado = await _medicoFlujo.EliminarMedicacionPaciente(idMedicacionPaciente);
            if (resultado == 0)
                return BadRequest("Lo medicacion a eliminar no existe");
            return NoContent();
        }

        [HttpDelete("Medico_EliminarPadecimientoPaciente/{idEnferDiagnostico}")]
        public async Task<IActionResult> EliminarPadecimientoPaciente([FromRoute] int idEnferDiagnostico) // agregado y probado por eliecer
        {
            var resultado = await _medicoFlujo.EliminarPadecimientoPaciente(idEnferDiagnostico);
            if (resultado == 0)
                return BadRequest("El diagnostico a eliminar no existe");
            return NoContent();
        }

        [HttpGet("ObtenerCita/{idCita}")]
        public async Task<IActionResult> ObtenerCita([FromRoute] int idCita) // agregado por elicer, se usa el created actiojn de agregar cita, no se usa para mas que eso
        {
            var resultado = await _pacienteFlujo.ObtenerCita(idCita);
            if (resultado == null)
                return NotFound();
            return Ok(resultado);
        }

        [HttpDelete("EliminarPerfil/{idPersona}")]
        public async Task<IActionResult> EliminarPerfil(Guid idPersona)
        {
            var resultado = await _pacienteFlujo.EliminarPerfil(idPersona);
            if (resultado == Guid.Empty)
                return BadRequest("El diagnostico a eliminar no existe");
            return NoContent();
        }

        [HttpGet("ObtenerPersona/{idPersona}")]
        public async Task<IActionResult> ObtenerPersona([FromRoute] Guid idPersona) // agregado por elicer, se usa el created actiojn de creacion de perfil, no se usa para mas que eso
        {
            var resultado = await _pacienteFlujo.ObtenerPersona(idPersona);
            if (resultado == null)
                return NotFound();
            return Ok(resultado);
        }

        [HttpPost("AgregarEnfermedadDiagnostico")]
        public async Task<IActionResult> CrearEnfermedadDiagnostico([FromBody] EnfermedaDiagnosticoMapping enfermedadDiagnostico)
        {
            var resultado = await _medicoFlujo.CrearEnfermedadDiagnostico(enfermedadDiagnostico);
            return CreatedAtAction(nameof(ObtenerPadecimientoPaciente), new { idEnferDiagnostico = resultado }, null);
        }

        [HttpPost("AgregarPacienteMedicacion")]
        public async Task<IActionResult> CrearPacienteMedicacion([FromBody] MedicacionPacienteMapping medicacionPaciente)
        {
            var resultado = await _medicoFlujo.CrearPacienteMedicacion(medicacionPaciente);
            return CreatedAtAction(nameof(ObtenerMedicacionPaciente), new { idMedicacionPaciente = resultado }, null);
        }

        [HttpGet("FullObtenerPadecimientoPaciente/{idEnferDiagnostico}")]
        public async Task<IActionResult> ObtenerPadecimientoPaciente([FromRoute] int idEnferDiagnostico)
        {
            var resultado = await _medicoFlujo.ObtenerPadecimientoPaciente(idEnferDiagnostico);
            if (resultado == null)
                return NotFound();
            return Ok(resultado);
        }

        [HttpGet("FullObtenerMedicacionPaciente/{idMedicacionPaciente}")]
        public async Task<IActionResult> ObtenerMedicacionPaciente([FromRoute] int idMedicacionPaciente)
        {
            var resultado = await _medicoFlujo.ObtenerMedicacionPaciente(idMedicacionPaciente);
            if (resultado == null)
                return NotFound();
            return Ok(resultado);
        }
    }
}
