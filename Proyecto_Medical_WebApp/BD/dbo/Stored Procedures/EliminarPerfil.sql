CREATE PROCEDURE EliminarPerfil
@IdPersona as uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM [dbo].[Persona]
	WHERE id_Persona = @IdPersona

	SELECT @IdPersona
END