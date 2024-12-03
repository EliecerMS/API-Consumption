CREATE PROCEDURE ObtenerDatosPaciente
@IdPaciente int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT [id_Paciente]
      ,[nombre]
      ,[primer_Apellido]
      ,[segundo_Apellido]
      ,[fecha_Nacimiento]
      ,[genero]
      ,[email]
      ,[telefono]
      ,[edad]
      ,[peso]
      ,[estatura]
      ,[cedula]
  FROM [dbo].[Paciente]
  WHERE [id_Paciente] = @IdPaciente
END