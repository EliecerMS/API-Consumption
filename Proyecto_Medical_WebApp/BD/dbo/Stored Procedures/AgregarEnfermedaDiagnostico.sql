CREATE PROCEDURE [dbo].[AgregarEnfermedaDiagnostico]
@idEnferDiagnostico as int,
@idCita as int,
@idEnfermedad as int,
@notasDiagnostico as nvarchar(max),
@faseEnfermedad as nvarchar(50),
@fechaDiagnostico as date
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Enfermedad_Diagnostico]
           ([id_EnferDiagnostico]
           ,[id_Cita]
           ,[id_Enfermedad]
           ,[notas_Diagnostico]
           ,[fase_Enfermedad]
           ,[fecha_Diagnostico])
     VALUES
           (@idEnferDiagnostico,
            @idCita,
            @idEnfermedad,
			@notasDiagnostico,
			@faseEnfermedad,
			@fechaDiagnostico)

			SELECT @idEnferDiagnostico
END