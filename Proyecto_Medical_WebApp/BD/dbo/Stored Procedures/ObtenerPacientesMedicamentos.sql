CREATE PROCEDURE [dbo].[ObtenerPacientesMedicamentos]
    @id_Medico INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        mp.id_Medicacion_Paciente AS Id,
        p.nombre AS NombrePaciente,
        m.nombre AS NombreMedicamento
    FROM 
        Cita c
    INNER JOIN 
        Paciente p ON c.id_Paciente = p.id_Paciente
    INNER JOIN 
        Medicacion_Paciente mp ON c.id_Cita = mp.id_Cita
    INNER JOIN 
        Medicamento m ON mp.id_Medicamento = m.id_Medicamento
    WHERE 
        c.id_Medico = @id_Medico;
END;