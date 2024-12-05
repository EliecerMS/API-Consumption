CREATE PROCEDURE  [dbo].[PacientesMedico]
@IdMedico uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	WITH RankedCitas AS (
		SELECT
			pa.id_Paciente,
			CONCAT(pe.nombre, ' ', pe.primer_Apellido) AS nombre, 
			pa.estatura,  
			pa.peso,      
			ci.motivo,
			ci.fecha_Cita,
			ROW_NUMBER() OVER (PARTITION BY pa.id_Paciente ORDER BY ci.fecha_Cita DESC) AS rn
		FROM
			Paciente AS pa
		INNER JOIN
			Persona AS pe ON pe.id_Persona = pa.id_Paciente  
		INNER JOIN
			Cita AS ci ON ci.id_Paciente = pa.id_Paciente
		WHERE
			ci.id_Medico = @IdMedico  
	)
	SELECT
		id_Paciente,
		nombre,
		estatura,
		peso,
		motivo,
		fecha_Cita
	FROM
		RankedCitas
	WHERE
		rn = 1;
END