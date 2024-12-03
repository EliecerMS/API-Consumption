CREATE PROCEDURE ObtenerDetallesCita
    @IdCita INT
AS
BEGIN
    SELECT 
        c.IdCita,
        c.IdPaciente,
        c.IdMedico,
        c.FechaHora,
        c.Motivo,
        c.Diagnostico,
        c.Observaciones
    FROM 
        Citas c
    WHERE 
        c.IdCita = @IdCita;
END;