CREATE PROCEDURE PacienteObtenerPadecimientos 
	@IdPaciente int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT 
    ED.id_EnferDiagnostico AS IdDiagnostico,
    E.nombre AS NombreEnfermedad,
    ED.fecha_Diagnostico AS FechaDiagnostico,
    C.motivo AS MotivoCita,
    C.id_Cita AS IdCita,
    C.id_Medico AS IdMedico
FROM 
    Enfermedad_Diagnostico ED
JOIN 
    Enfermedad E ON ED.id_Enfermedad = E.id_Enfermedad
JOIN 
    Cita C ON ED.id_Cita = C.id_Cita
WHERE 
    ED.id_Paciente = @IdPaciente;

END