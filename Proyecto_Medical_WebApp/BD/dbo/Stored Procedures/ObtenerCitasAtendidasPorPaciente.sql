CREATE PROCEDURE ObtenerCitasAtendidasPorPaciente
    @IdPaciente INT
AS
BEGIN
    SELECT 
        c.IdCita,
        c.FechaCita,
        c.Motivo,
        m.Nombre AS NombreMedico
    FROM Citas c
    INNER JOIN Medicos m ON c.IdMedico = m.IdMedico
    WHERE c.IdPaciente = @IdPaciente AND c.Atendida = 1;
END;
