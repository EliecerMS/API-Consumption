
CREATE PROCEDURE [dbo].[EliminarCitaNoAtendida]

@IdCita as int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DELETE
	FROM [dbo].[Cita]
	WHERE id_Cita= @IdCita
	SELECT @IdCita

END