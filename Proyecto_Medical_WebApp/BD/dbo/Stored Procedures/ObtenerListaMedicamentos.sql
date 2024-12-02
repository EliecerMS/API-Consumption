CREATE PROCEDURE ObtenerListaMedicamentos
AS
BEGIN
    SELECT 
        IdMedicamento,
        Nombre,
        Descripcion,
        Dosis
    FROM Medicamentos;
END;
