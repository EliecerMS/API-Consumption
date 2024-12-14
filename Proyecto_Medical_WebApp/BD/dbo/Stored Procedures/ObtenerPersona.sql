CREATE PROCEDURE ObtenerPersona
@IdPersona as uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM [dbo].[Persona]
	WHERE id_Persona = @IdPersona
END