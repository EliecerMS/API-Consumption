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
    }
}
