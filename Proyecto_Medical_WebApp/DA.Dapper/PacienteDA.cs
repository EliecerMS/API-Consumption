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

        public async Task<Paciente_DetallesPadecimiento> ObtenerPacienteDetallesPadecimiento(int idPaciente, int idEnfermedadDiagnostico, int idCita, int idMedico)
        {
            Paciente_DetallesPadecimiento? resultadoConsulta = await ObtenerDetallesPadecimiento(idPaciente, idEnfermedadDiagnostico, idCita, idMedico);
            if (resultadoConsulta == null)
                return null;
            return resultadoConsulta;
        }

        public async Task<Paciente_DetallesMedicacion> PacienteObtenerDetallesMedicacion(int IdMedicacionPaciente)
        {
            Paciente_DetallesMedicacion? resultadoConsulta = await ObtenerDetallesMedicacion(IdMedicacionPaciente);
            if (resultadoConsulta == null)
                return null;
            return resultadoConsulta;
        }

        private async Task<Paciente_DetallesMedicacion?> ObtenerDetallesMedicacion(int IdMedicacionPaciente)
        {
            string sql = @"PacienteDetallesMedicacion";
            var resultadoConsulta = await _sqlConnection.QueryAsync<Paciente_DetallesMedicacion>(sql, new { IdMedicacionPaciente = IdMedicacionPaciente });
            return resultadoConsulta.FirstOrDefault();
        }

        private async Task<Paciente_DetallesPadecimiento?> ObtenerDetallesPadecimiento(int idPaciente, int idEnfermedadDiagnostico, int idCita, int idMedico)
        {
            string sql = @"PacienteDetallesPadecimiento";
            var resultadoConsulta = await _sqlConnection.QueryAsync<Paciente_DetallesPadecimiento>(sql, new { IdPaciente = idPaciente, IdEnferDiagnostico = idEnfermedadDiagnostico, IdCita = idCita, IdMedico = idMedico });
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
