CREATE PROCEDURE ObtenerDatosPaciente
@IdPaciente uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT [id_Paciente]
       [peso]
      ,[estatura]
  FROM [dbo].[Paciente]
  WHERE [id_Paciente] = @IdPaciente
END