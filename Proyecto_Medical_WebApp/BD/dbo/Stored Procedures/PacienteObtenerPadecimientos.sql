CREATE PROCEDURE PacienteObtenerPadecimientos 
	@IdPaciente uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT 
    ED.id_EnferDiagnostico, 
    E.nombre AS NombreEnfermedad,
    ED.fecha_Diagnostico,
    C.motivo AS MotivoCita,
    C.id_Cita
	FROM 
    Enfermedad_Diagnostico ED
	INNER JOIN 
    Enfermedad E ON ED.id_Enfermedad = E.id_Enfermedad
	INNER JOIN 
    Cita C ON ED.id_Cita = C.id_Cita  
	WHERE 
    C.id_Paciente = @IdPaciente;  

END