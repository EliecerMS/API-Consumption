CREATE PROCEDURE [dbo].[ObtenerEnfermedadDiagnostico]
    @id_EnferDiagnostico INT
AS
BEGIN
    SELECT 
        e.nombre AS nombre, -- Cambiado para que coincida con el modelo
        ed.fase_Enfermedad AS fase_Enfermedad,
        ed.notas_Diagnostico AS notas_Diagnostico
    FROM 
        Enfermedad_Diagnostico ed
    INNER JOIN 
        Enfermedad e ON ed.id_Enfermedad = e.id_Enfermedad
    WHERE 
        ed.id_EnferDiagnostico = @id_EnferDiagnostico;
END;