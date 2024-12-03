CREATE PROCEDURE EditarDatosPersonalesPaciente
@IdPaciente int,
@PacienteNombre nvarchar,
@PacientePrimerApellido nvarchar,
@PacienteSegundoApellido nvarchar,
@PacienteFechaNacimiento date,
@PacienteGenero nvarchar,
@PacienteEmail nvarchar,
@PacienteTelefono nvarchar,
@PacienteEdad nvarchar,
@PacienteCedula nvarchar
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   UPDATE [dbo].[Paciente]
   SET [nombre] = @PacienteNombre
      ,[primer_Apellido] = @PacientePrimerApellido
      ,[segundo_Apellido] = @PacienteSegundoApellido
      ,[fecha_Nacimiento] = @PacienteFechaNacimiento
      ,[genero] = @PacienteGenero
      ,[email] = @PacienteEmail
      ,[telefono] = @PacienteTelefono
      ,[edad] = @PacienteEdad
      ,[cedula] = @PacienteCedula
 WHERE id_Paciente = @IdPaciente
	
END