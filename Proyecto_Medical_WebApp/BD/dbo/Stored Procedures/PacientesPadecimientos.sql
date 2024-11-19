CREATE PROCEDURE [dbo].[PacientesPadecimientos]
	@IdMedico int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT 
		CONCAT(p.nombre, ' ', p.primer_Apellido, ' ', p.segundo_Apellido) AS NombreCompletoPaciente,
		e.nombre AS Enfermedad, 
		ed.id_EnferDiagnostico AS IdEnfermedadDiagnostico
	FROM Cita c
		INNER JOIN Paciente p ON c.id_Paciente = p.id_Paciente
		INNER JOIN Medico m ON c.id_Medico = m.id_Medico  
		INNER JOIN Enfermedad_Diagnostico ed ON p.id_Paciente = ed.id_Paciente  
		INNER JOIN Enfermedad e ON ed.id_Enfermedad = e.id_Enfermedad 
	WHERE m.id_Medico = @IdMedico  

END