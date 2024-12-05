CREATE PROCEDURE [dbo].[PacientesPadecimientos]
	@IdMedico uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT 
    CONCAT(pe.nombre, ' ', pe.primer_Apellido, ' ', pe.segundo_Apellido) AS NombreCompletoPaciente,
    e.nombre AS Enfermedad, 
    ed.id_EnferDiagnostico AS IdEnfermedadDiagnostico
	FROM Cita c
		INNER JOIN Paciente p ON c.id_Paciente = p.id_Paciente
		INNER JOIN Persona pe ON p.id_Paciente = pe.id_Persona  
		INNER JOIN Medico m ON c.id_Medico = m.id_Medico  
		INNER JOIN Enfermedad_Diagnostico ed ON c.id_Cita = ed.id_Cita  
		INNER JOIN Enfermedad e ON ed.id_Enfermedad = e.id_Enfermedad 
	WHERE m.id_Medico = @IdMedico; 

END