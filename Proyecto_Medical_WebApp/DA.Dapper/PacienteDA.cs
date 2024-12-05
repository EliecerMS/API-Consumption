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
    }
}
