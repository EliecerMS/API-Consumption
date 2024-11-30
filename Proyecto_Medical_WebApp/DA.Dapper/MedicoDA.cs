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

        public async Task<Medico_DetallesPaciente> ObtenerDetallesPaciente(int IdPaciente)
        {
            Medico_DetallesPaciente? resultadoConsulta = await ObtenerDetalles(IdPaciente);
            if (resultadoConsulta == null)
                return null;
            return resultadoConsulta;
        }

        private async Task<Medico_DetallesPaciente?> ObtenerDetalles(int IdPaciente)
        {
            string sql = @"DetallesPaciente";
            var resultadoConsulta = await _sqlConnection.QueryAsync<Medico_DetallesPaciente>(sql, new { IdPaciente = IdPaciente });
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

        public async Task<EnfermedadDiagnosticoBD> ObtenerEnfermedadDiagnostico(int Id_EnfermedadDiagnostico)
        {
            string sql = @"EnfermedadDiagnostico";
            var resultadoConsulta = await _sqlConnection.QueryAsync<EnfermedadDiagnosticoBD>(sql, new { Id_EnfermedadDiagnostico = Id_EnfermedadDiagnostico });
            return resultadoConsulta.FirstOrDefault();
        }

        public async Task<MedicamentoBD> ObtenerMedicamento(int Id_Medicamento)
        {
            string sql = @"Medicamento";
            var resultadoConsulta = await _sqlConnection.QueryAsync<MedicamentoBD>(sql, new { Id_Medicamento = Id_Medicamento });
            return resultadoConsulta.FirstOrDefault();
        }

        public async Task<int> EditarPesoAlturaPaciente(int IdPaciente, Medico_PesoAltura pacienteInformacion)
        {
            string sql = @"EditarPesoAlturaPaciente";
            Paciente_InformacionBD? resultadoConsultaPaciente = await ObtenerPaciente(IdPaciente);
            if (resultadoConsultaPaciente == null)
                return 0;
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<int>(sql, new { IdPaciente = IdPaciente, PacienteEstatura = pacienteInformacion.estatura, PacientePeso = pacienteInformacion.peso });
            return resultadoConsulta;
        }

        public async Task<Paciente_InformacionBD> ObtenerPaciente(int IdPaciente)
        {
            string sql = @"ObtenerDatosPaciente";
            var resultadoConsulta = await _sqlConnection.QueryAsync<Paciente_InformacionBD>(sql, new { IdPaciente = IdPaciente });
            return resultadoConsulta.FirstOrDefault();
        }


    }
}
