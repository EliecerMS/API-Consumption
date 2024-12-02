CREATE PROCEDURE [dbo].[ActualizarDiagnostico]
    @id_EnferDiagnostico INT,
    @fase_Enfermedad NVARCHAR(50),
    @notas_Diagnostico NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Enfermedad_Diagnostico
    SET 
        fase_Enfermedad = @fase_Enfermedad,
        notas_Diagnostico = @notas_Diagnostico
    WHERE 
        id_EnferDiagnostico = @id_EnferDiagnostico;
END;