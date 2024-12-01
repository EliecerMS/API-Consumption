CREATE PROCEDURE DetalleMedicamento
    @id_Medicamento INT,
    @id_Paciente INT
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
    WHERE 
        mp.id_Medicamento = @id_Medicamento
        AND mp.id_Paciente = @id_Paciente;
END;