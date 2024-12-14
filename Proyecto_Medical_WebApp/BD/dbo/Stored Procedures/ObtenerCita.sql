CREATE PROCEDURE [dbo].[ObtenerCita]
	@IdCita as int
AS
BEGIN

	SET NOCOUNT ON;

SELECT *
  FROM [dbo].[Cita]
  WHERE id_Cita= @IdCita
END