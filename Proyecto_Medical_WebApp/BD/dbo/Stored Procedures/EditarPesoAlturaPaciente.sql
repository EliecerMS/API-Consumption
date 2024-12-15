CREATE PROCEDURE [dbo].[EditarPesoAlturaPaciente]
@IdPaciente uniqueidentifier,
@PacientePeso int,
@PacienteEstatura int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE [dbo].[Paciente]
   SET [peso] = @PacientePeso
      ,[estatura] = @PacienteEstatura
 WHERE id_Paciente = @IdPaciente
SELECT @IdPaciente	
END