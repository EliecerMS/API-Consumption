CREATE PROCEDURE [dbo].[AgregarMedicacionPaciente]
@idMedicacionPaciente as int,
@idMedicamento as int, 
@idCita as int, 
@dosis as nvarchar(50), 
@instrucciones as nvarchar(50),  
@fechaPreesctrito  as date
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Medicacion_Paciente]
           ([id_Medicacion_Paciente]
           ,[id_Medicamento]
           ,[id_Cita]
           ,[dosis]
           ,[intrucciones]
           ,[fecha_Preesctrito])
     VALUES
           (@idMedicacionPaciente,
            @idMedicamento,
            @idCita,
			@dosis,
			@instrucciones,
            @fechaPreesctrito)

	SELECT @idMedicacionPaciente
END