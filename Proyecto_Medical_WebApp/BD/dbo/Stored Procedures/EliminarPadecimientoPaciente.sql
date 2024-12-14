
CREATE PROCEDURE EliminarPadecimientoPaciente
@IdEnferDiagnostico as int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DELETE
	FROM [dbo].[Enfermedad_Diagnostico]
		WHERE id_EnferDiagnostico=@IdEnferDiagnostico

	SELECT @IdEnferDiagnostico
END