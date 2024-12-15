CREATE PROCEDURE [dbo].[CrearPerfil]
	@idPersona as uniqueidentifier,
	@nombre as nvarchar(max),
	@primerApellido as nvarchar(max),
	@segundoApellido as nvarchar(max),
	@fechaNacimiento as date,
	@genero as nvarchar(max),
	@email as nvarchar(max),
	@telefono as nvarchar(max),
	@edad as nvarchar(max),
	@identificacion as nvarchar(max),
	@rol as nvarchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Persona]
           ([id_Persona]
           ,[nombre]
           ,[primer_Apellido]
           ,[segundo_Apellido]
           ,[fecha_Nacimiento]
           ,[genero]
		   ,[email]
		   ,[telefono]
		   ,[edad]
		   ,[identificacion]
		   ,[rol])
     VALUES
           (@idPersona,
            @nombre,
            @primerApellido,
			@segundoApellido,
			@fechaNacimiento,
			@genero,
			@email,
			@telefono,
			@edad,
			@identificacion,
			@rol)

	SELECT @idPersona
END