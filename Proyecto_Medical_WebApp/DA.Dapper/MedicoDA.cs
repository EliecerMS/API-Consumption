using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DA.Dapper
{
    public class MedicoDA : IMedicoDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        public MedicoDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorioDapper();
        }

        public async Task<DetallesPaciente> ObtenerDetallesPaciente(int IdPaciente)
        {
            DetallesPaciente? resultadoConsulta = await ObtenerDetalles(IdPaciente);
            if (resultadoConsulta == null)
                return null;
            return resultadoConsulta;
        }

        private async Task<DetallesPaciente?> ObtenerDetalles(int IdPaciente)
        {
            string sql = @"DetallesPaciente";
            var resultadoConsulta = await _sqlConnection.QueryAsync<DetallesPaciente>(sql, new { IdPaciente = IdPaciente });
            return resultadoConsulta.FirstOrDefault();
        }

        public async Task<IEnumerable<PacientesMedicoBD>> ObtenerListaPacientes(int idMedico)
        {
            try
            {
                string sql = @"PacientesMedico";
                var resultadoConsulta = await _sqlConnection.QueryAsync<PacientesMedicoBD>(sql, new { IdMedico = idMedico });
                return resultadoConsulta;
            }
            catch (Exception)
            {

                throw new Exception("Error obteniendo los pacientes de la BD");
            }
        }

        public async Task<IEnumerable<PacientesPadecimientosBD>> ObtenerListaPacientesYPadecimientos(int medicoId)
        {
            try
            {
                string sql = @"PacientesPadecimientos";
                var resultadoConsulta = await _sqlConnection.QueryAsync<PacientesPadecimientosBD>(sql, new { IdMedico = medicoId });
                return resultadoConsulta;
            }
            catch (Exception)
            {

                throw new Exception("Error obteniendo los detalles de padecimientos de los pacientes");
            }
        }
    }
}
