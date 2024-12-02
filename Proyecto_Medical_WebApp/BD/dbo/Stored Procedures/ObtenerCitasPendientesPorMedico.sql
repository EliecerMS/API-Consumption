CREATE PROCEDURE ObtenerCitasPendientesPorMedico
    @IdMedico INT
AS
BEGIN
    SELECT 
        c.IdCita,
        c.FechaCita,
        c.Motivo,
        p.Nombre AS NombrePaciente
    FROM Citas c
    INNER JOIN Pacientes p ON c.IdPaciente = p.IdPaciente
    WHERE c.IdMedico = @IdMedico AND c.Atendida = 0;
END;
