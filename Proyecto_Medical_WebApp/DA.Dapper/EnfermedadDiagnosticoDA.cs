using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;


namespace DA.Dapper
{
    public class EnfermedadDiagnosticoDA : IEnfermedadDiagnosticoDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        public EnfermedadDiagnosticoDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorioDapper();
        }

        public async Task<IEnumerable<EnfermedadDiagnosticoBD>> Obtener()
        {
            try
            {
                string sql = @"ObtenerEnfermedadDiagnosticos";
                var resultadoConsulta = await _sqlConnection.QueryAsync<EnfermedadDiagnosticoBD>(sql);
                return resultadoConsulta;
            }
            catch (Exception)
            {

                throw new Exception("Error obteniendo las enfermedades en la BD");
            }
        }

        public async Task<EnfermedadDiagnosticoBD> Obtener(Guid Id_EnfermedadDiagnosticoBD)
        {
            EnfermedadDiagnosticoBD? resultadoConsulta = await ObtenerEnfermedadDiagnostico(Id_EnfermedadDiagnosticoBD);
            if (resultadoConsulta == null)
                return null;
            return resultadoConsulta;
        }

        private async Task<EnfermedadDiagnosticoBD?> ObtenerEnfermedadDiagnostico(Guid Id_EnfermedadDiagnosticoBD)
        {
            string sql = @"ObtenerEnfermedadDiagnostico";
            var resultadoConsulta = await _sqlConnection.QueryAsync<EnfermedadDiagnosticoBD>(sql, new { Id_EnfermedadDiagnosticoBD = Id_EnfermedadDiagnosticoBD });
            return resultadoConsulta.FirstOrDefault();
        }
    }
}

