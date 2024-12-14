CREATE PROCEDURE MedicoObtenerMedicacionDelPaciente
@IdMedPaciente as int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT *
  FROM [dbo].[Medicacion_Paciente]
  WHERE id_Medicacion_Paciente= @IdMedPaciente

END