CREATE PROCEDURE ObtenerEnfermedadDiagnostico
    @id_EnferDiagnostico INT
AS
BEGIN
    SELECT 
        e.nombre AS NombreEnfermedad,
        ed.fase_Enfermedad AS FaseEnfermedad,
        ed.notas_Diagnostico AS NotasDiagnostico
    FROM 
        Enfermedad_Diagnostico ed
    INNER JOIN 
        Enfermedad e ON ed.id_Enfermedad = e.id_Enfermedad
    WHERE 
        ed.id_EnferDiagnostico = @id_EnferDiagnostico;
END;