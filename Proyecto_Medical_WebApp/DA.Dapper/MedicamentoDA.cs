using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;


namespace DA.Dapper
{
    public class MedicamentoDA : IMedicamentoDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        public MedicamentoDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorioDapper();
        }

        public async Task<IEnumerable<MedicamentoBD>> Obtener()
        {
            try
            {
                string sql = @"ObtenerMedicamentos";
                var resultadoConsulta = await _sqlConnection.QueryAsync<MedicamentoBD>(sql);
                return resultadoConsulta;
            }
            catch (Exception)
            {

                throw new Exception("Error obteniendo los medicamentos de la BD");
            }
        }

        public async Task<MedicamentoBD> Obtener(Guid Id_Medicamento)
        {
            MedicamentoBD? resultadoConsulta = await ObtenerMedicamento(Id_Medicamento);
            if (resultadoConsulta == null)
                return null;
            return resultadoConsulta;
        }

        private async Task<MedicamentoBD?> ObtenerMedicamento(Guid Id_Medicamento)
        {
            string sql = @"ObtenerMedicamento";
            var resultadoConsulta = await _sqlConnection.QueryAsync<MedicamentoBD>(sql, new { Id_Medicamento = Id_Medicamento });
            return resultadoConsulta.FirstOrDefault();
        }
    }
}

