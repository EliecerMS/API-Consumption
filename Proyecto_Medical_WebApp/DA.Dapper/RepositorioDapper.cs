using Abstracciones.Interfaces.DA;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace DA.Dapper
{
    public class RepositorioDapper : IRepositorioDapper
    {
        private readonly IConfiguration _configuration;
        private readonly SqlConnection _Conexion;

        public RepositorioDapper(IConfiguration configuration)
        {
            _configuration = configuration;
            _Conexion = new SqlConnection(_configuration.GetConnectionString("BD"));
        }

        

        public SqlConnection ObtenerRepositorioDapper()
        {
            return _Conexion;
        }
    }
}
