CREATE PROCEDURE MedicoObtenerDiagnosticoDelPaciente
	@IdEnferDiagnostico as int
AS
BEGIN

	SET NOCOUNT ON;

SELECT *
  FROM [dbo].[Enfermedad_Diagnostico]
  WHERE id_EnferDiagnostico= @IdEnferDiagnostico
END