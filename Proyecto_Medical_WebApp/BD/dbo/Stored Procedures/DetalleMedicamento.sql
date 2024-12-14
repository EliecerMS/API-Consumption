CREATE PROCEDURE [dbo].[DetalleMedicamento]
    @id_Medicamento INT,
    @id_Paciente UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        m.nombre AS NombreMedicamento,
        mp.dosis AS Dosis,
        mp.fecha_Preesctrito AS FechaPrescrito,
        mp.intrucciones AS Instrucciones
    FROM 
        Medicamento m
    INNER JOIN 
        Medicacion_Paciente mp ON m.id_Medicamento = mp.id_Medicamento
    INNER JOIN 
        Cita c ON mp.id_Cita = c.id_Cita
    WHERE 
        mp.id_Medicamento = @id_Medicamento
        AND c.id_Paciente = @id_Paciente;
END;