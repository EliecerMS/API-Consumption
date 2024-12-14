
CREATE PROCEDURE EliminarMedicacionPaciente
@IdMedPaciente as int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DELETE
	FROM [dbo].[Medicacion_Paciente]
		WHERE id_Medicacion_Paciente=@IdMedPaciente

	SELECT @IdMedPaciente
END