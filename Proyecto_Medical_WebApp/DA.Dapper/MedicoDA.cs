using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

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

        public async Task<Medico_DetallesPaciente> ObtenerDetallesPaciente(Guid IdPaciente) //cambiado el SP y probado por eliecer
        {
            Medico_DetallesPaciente? resultadoConsulta = await ObtenerDetalles(IdPaciente);
            if (resultadoConsulta == null)
                return null;
            return resultadoConsulta;
        }

        private async Task<Medico_DetallesPaciente?> ObtenerDetalles(Guid IdPaciente) //cambiado el SP y probado por eliecer
        {
            string sql = @"DetallesPaciente";
            var resultadoConsulta = await _sqlConnection.QueryAsync<Medico_DetallesPaciente>(sql, new { IdPaciente = IdPaciente });
            return resultadoConsulta.FirstOrDefault();
        }

        public async Task<IEnumerable<PacientesMedicoBD>> ObtenerListaPacientes(Guid idMedico) //cambiado el SP y probado por eliecer
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

        public async Task<IEnumerable<PacientesPadecimientosBD>> ObtenerListaPacientesYPadecimientos(Guid medicoId) //cambiado el SP y probado por eliecer
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

        public async Task<EnfermedadDiagnosticoBD> ObtenerEnfermedadDiagnostico(int id_EnferDiagnostico)
        {
            string sql = "ObtenerEnfermedadDiagnostico";
            var resultadoConsulta = await _sqlConnection.QueryAsync<EnfermedadDiagnosticoBD>(
                sql,
                new { id_EnferDiagnostico = id_EnferDiagnostico },
                commandType: CommandType.StoredProcedure // Especifica que es un procedimiento almacenado
            );
            return resultadoConsulta.FirstOrDefault();
        }


        public async Task<MedicamentoBD> ObtenerDetalleMedicamento(int id_Medicamento, Guid id_Paciente)
        {
            string sql = @"DetalleMedicamento";
            var parametros = new { id_Medicamento, id_Paciente };
            var resultadoConsulta = await _sqlConnection.QueryAsync<MedicamentoBD>(
                sql,
                parametros,
                commandType: CommandType.StoredProcedure
            );
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

        public async Task<IEnumerable<PacienteMedicamentoBD>> ObtenerListaPacienteMedicamento(Guid id_Medico)
        {
            try
            {
                string sql = "ObtenerPacientesMedicamentos";
                var resultadoConsulta = await _sqlConnection.QueryAsync<PacienteMedicamentoBD>(
                    sql,
                    new { id_Medico = id_Medico },
                    commandType: CommandType.StoredProcedure
                );
                return resultadoConsulta;
            }
            catch (Exception)
            {
                throw new Exception("Error obteniendo los pacientes y sus medicamentos de la BD");
            }
        }


        public async Task<int> EditarDiagnosticoPaciente(int id_EnferDiagnostico, Medico_EnfermedadDiagnostico enfermedadDiagnostico)
        {
            try
            {
                string sql = "ActualizarDiagnostico";
                var parametros = new
                {
                    id_EnferDiagnostico = id_EnferDiagnostico,
                    fase_Enfermedad = enfermedadDiagnostico.fase_Enfermedad,
                    notas_Diagnostico = enfermedadDiagnostico.notas_Diagnostico
                };

                var filasAfectadas = await _sqlConnection.ExecuteAsync(sql, parametros, commandType: CommandType.StoredProcedure);
                return filasAfectadas;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar el diagnóstico: {ex.Message}");
            }
        }

        public async Task<IEnumerable<CitaDetallesBD>> ObtenerCitasPendientesPorMedico(int idMedico)
        {
            try
            {
                string sql = "ObtenerCitasPendientesPorMedico"; // Nombre del procedimiento almacenado
                var resultadoConsulta = await _sqlConnection.QueryAsync<CitaDetallesBD>(
                    sql,
                    new { IdMedico = idMedico },
                    commandType: CommandType.StoredProcedure
                );
                return resultadoConsulta;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener citas pendientes: {ex.Message}");
            }
        }

        public async Task<IEnumerable<CitaDetallesBD>> ObtenerCitasAtendidasPorMedico(int idMedico)
        {
            try
            {
                string sql = "ObtenerCitasAtendidasPorMedico"; // Nombre del procedimiento almacenado
                var resultadoConsulta = await _sqlConnection.QueryAsync<CitaDetallesBD>(
                    sql,
                    new { IdMedico = idMedico },
                    commandType: CommandType.StoredProcedure
                );
                return resultadoConsulta;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener citas atendidas: {ex.Message}");
            }
        }

        public async Task<IEnumerable<MedicamentoBD>> ObtenerListaMedicamentos()
        {
            try
            {
                string sql = "ObtenerListaMedicamentos"; // Nombre del procedimiento almacenado
                var resultadoConsulta = await _sqlConnection.QueryAsync<MedicamentoBD>(
                    sql,
                    commandType: CommandType.StoredProcedure
                );
                return resultadoConsulta;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener lista de medicamentos: {ex.Message}");
            }
        }

        public Task<int> EditarCita(int idCita, Medico_CitaEdicion citaEdicion)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MedicacionDetalladaBD>> ObtenerMedicacionesDetalladas()
        {
            throw new NotImplementedException();
        }

        public async Task<int> EliminarMedicacionPaciente(int idMedicacionPaciente) //agregado por eliecer
        {
            string sql = @"EliminarMedicacionPaciente";
            MedicacionPacienteMapping? resultadoConsultaMedicacion = await ObtenerMedicacionPaciente(idMedicacionPaciente);
            if (resultadoConsultaMedicacion == null)
                return 0;
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<int>(sql, new { IdMedPaciente = idMedicacionPaciente });
            return resultadoConsulta;
        }

        public async Task<MedicacionPacienteMapping?> ObtenerMedicacionPaciente(int idMedicacionPaciente) //agregado por eliecer
        {
            string sql = @"MedicoObtenerMedicacionDelPaciente";
            var resultadoConsulta = await _sqlConnection.QueryAsync<MedicacionPacienteMapping>(sql, new { IdMedPaciente = idMedicacionPaciente });
            return resultadoConsulta.FirstOrDefault();
        }

        public async Task<int> EliminarPadecimientoPaciente(int idEnferDiagnostico) //agregado por eliecer
        {
            string sql = @"EliminarPadecimientoPaciente";
            EnfermedaDiagnosticoMapping? resultadoConsultaPadecimiento = await ObtenerPadecimientoPaciente(idEnferDiagnostico);
            if (resultadoConsultaPadecimiento == null)
                return 0;
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<int>(sql, new { IdEnferDiagnostico = idEnferDiagnostico });
            return resultadoConsulta;
        }

        public async Task<EnfermedaDiagnosticoMapping?> ObtenerPadecimientoPaciente(int idEnferDiagnostico) //agregado por eliecer
        {
            string sql = @"MedicoObtenerDiagnosticoDelPaciente";
            var resultadoConsulta = await _sqlConnection.QueryAsync<EnfermedaDiagnosticoMapping>(sql, new { IdEnferDiagnostico = idEnferDiagnostico });
            return resultadoConsulta.FirstOrDefault();
        }

        public async Task<int> CrearEnfermedadDiagnostico(EnfermedaDiagnosticoMapping enfermedadDiagnostico) // agregado por eliecer
        {
            string sql = @"AgregarEnfermedaDiagnostico";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<int>(sql, new
            {
                idEnferDiagnostico = enfermedadDiagnostico.id_EnferDiagnostico,
                idCita = enfermedadDiagnostico.id_Cita,
                idEnfermedad = enfermedadDiagnostico.id_Enfermedad,
                notasDiagnostico = enfermedadDiagnostico.notas_Diagnostico,
                faseEnfermedad = enfermedadDiagnostico.fase_Enfermedad,
                fechaDiagnostico = enfermedadDiagnostico.fecha_Diagnostico
            });

            return resultadoConsulta;
        }

        public async Task<int> CrearPacienteMedicacion(MedicacionPacienteMapping medicacionPaciente) // agregado por eliecer
        {
            string sql = @"AgregarMedicacionPaciente";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<int>(sql, new
            {
                idMedicacionPaciente = medicacionPaciente.id_Medicacion_Paciente,
                idMedicamento = medicacionPaciente.id_Medicamento,
                idCita = medicacionPaciente.id_Cita,
                dosis = medicacionPaciente.dosis,
                instrucciones = medicacionPaciente.intrucciones,
                fechaPreesctrito = medicacionPaciente.fecha_Preesctrito
            });

            return resultadoConsulta;
        }
    }

}
