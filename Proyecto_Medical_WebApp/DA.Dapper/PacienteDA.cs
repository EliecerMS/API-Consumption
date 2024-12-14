using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DA.Dapper
{
    public class PacienteDA : IPacienteDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        public PacienteDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorioDapper();
        }

        public async Task<Paciente_DetallesPadecimiento> ObtenerPacienteDetallesPadecimiento(int idEnfermedadDiagnostico, int idCita) //cambiado el SP y probado por eliecer
        {
            Paciente_DetallesPadecimiento? resultadoConsulta = await ObtenerDetallesPadecimiento(idEnfermedadDiagnostico, idCita);
            if (resultadoConsulta == null)
                return null;
            return resultadoConsulta;
        }

        public async Task<Paciente_DetallesMedicacion> PacienteObtenerDetallesMedicacion(int IdMedicacionPaciente) //cambiado el SP y probado por eliecer

        {
            Paciente_DetallesMedicacion? resultadoConsulta = await ObtenerDetallesMedicacion(IdMedicacionPaciente);
            if (resultadoConsulta == null)
                return null;
            return resultadoConsulta;
        }

        private async Task<Paciente_DetallesMedicacion?> ObtenerDetallesMedicacion(int IdMedicacionPaciente) //cambiado el SP y probado por eliecer

        {
            string sql = @"PacienteDetallesMedicacion";
            var resultadoConsulta = await _sqlConnection.QueryAsync<Paciente_DetallesMedicacion>(sql, new { IdMedicacionPaciente = IdMedicacionPaciente });
            return resultadoConsulta.FirstOrDefault();
        }

        private async Task<Paciente_DetallesPadecimiento?> ObtenerDetallesPadecimiento(int idEnfermedadDiagnostico, int idCita) //cambiado el SP y probado por eliecer
        {
            string sql = @"PacienteDetallesPadecimiento";
            var resultadoConsulta = await _sqlConnection.QueryAsync<Paciente_DetallesPadecimiento>(sql, new { IdEnferDiagnostico = idEnfermedadDiagnostico, IdCita = idCita });
            return resultadoConsulta.FirstOrDefault();
        }

        public async Task<IEnumerable<CitaDetallesBD>> ObtenerCitasPendientesPorPaciente(int idPaciente)
        {
            try
            {
                string sql = "ObtenerCitasPendientesPorPaciente"; // Nombre del procedimiento almacenado
                var resultadoConsulta = await _sqlConnection.QueryAsync<CitaDetallesBD>(
                    sql,
                    new { IdPaciente = idPaciente },
                    commandType: CommandType.StoredProcedure
                );
                return resultadoConsulta;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener citas pendientes del paciente: {ex.Message}");
            }
        }

        public async Task<IEnumerable<CitaDetallesBD>> ObtenerCitasAtendidasPorPaciente(int idPaciente)
        {
            try
            {
                string sql = "ObtenerCitasAtendidasPorPaciente"; // Nombre del procedimiento almacenado
                var resultadoConsulta = await _sqlConnection.QueryAsync<CitaDetallesBD>(
                    sql,
                    new { IdPaciente = idPaciente },
                    commandType: CommandType.StoredProcedure
                );
                return resultadoConsulta;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener citas atendidas del paciente: {ex.Message}");
            }
        }

        public async Task<IEnumerable<PacientePadecimientosBD>> PacienteObtenerListaPadecimientos(Guid IdPaciente) // agregado y probado por eliecer
        {
            try
            {
                string sql = @"PacienteObtenerPadecimientos";
                var resultadoConsulta = await _sqlConnection.QueryAsync<PacientePadecimientosBD>(sql, new { IdPaciente = IdPaciente });
                return resultadoConsulta;
            }
            catch (Exception)
            {

                throw new Exception("Error obteniendo los detalles de padecimientos");
            }
        }

        public async Task<int> EliminarCitaPendiente(int idCita) // agregado y probado por eliecer
        {
            string sql = @"EliminarCitaNoAtendida";
            CitaMapping? resultadoConsultaCita = await ObtenerCita(idCita);
            if (resultadoConsultaCita == null)
                return 0;
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<int>(sql, new { IdCita = idCita });
            return resultadoConsulta;
        }

        public async Task<CitaMapping?> ObtenerCita(int idCita) // agregado y probado por eliecer
        {
            string sql = @"ObtenerCita";
            var resultadoConsulta = await _sqlConnection.QueryAsync<CitaMapping>(sql, new { IdCita = idCita });
            return resultadoConsulta.FirstOrDefault();
        }

        public async Task<Guid> EliminarPerfil(Guid idPersona) // agregado por eliecer
        {
            string sql = @"EliminarPerfil";
            Persona? resultadoConsultaPersona = await ObtenerPersona(idPersona);
            if (resultadoConsultaPersona == null)
                return Guid.Empty;
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(sql, new { IdPersona = idPersona });
            return resultadoConsulta;
        }

        public async Task<Persona?> ObtenerPersona(Guid idPersona) // agregado por eliecer
        {
            string sql = @"ObtenerPersona";
            var resultadoConsulta = await _sqlConnection.QueryAsync<Persona>(sql, new { IdPersona = idPersona });
            return resultadoConsulta.FirstOrDefault();
        }
    }
}
