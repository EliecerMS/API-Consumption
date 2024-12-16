CREATE PROCEDURE [dbo].[ObtenerPacientesMedicamentos]
    @id_Medico UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT  
	    mp.id_Medicacion_Paciente AS Id_Medicacion_Paciente, 
        pa.id_Paciente AS Id,   
        pe.nombre AS NombrePaciente,
        m.nombre AS NombreMedicamento
    FROM 
        Cita c
    INNER JOIN 
        Paciente pa ON c.id_Paciente = pa.id_Paciente
    INNER JOIN 
        Persona pe ON pa.id_Paciente = pe.id_Persona
    INNER JOIN 
        Medicacion_Paciente mp ON c.id_Cita = mp.id_Cita
    INNER JOIN 
        Medicamento m ON mp.id_Medicamento = m.id_Medicamento
    WHERE 
        c.id_Medico = @id_Medico;
END;