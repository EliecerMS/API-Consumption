using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;

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
    }
}
