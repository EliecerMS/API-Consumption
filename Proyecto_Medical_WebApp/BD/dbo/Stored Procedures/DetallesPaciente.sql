CREATE PROCEDURE [dbo].[DetallesPaciente]
	@IdPaciente uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

WITH UltimaMedicacionPreescrita AS (
    SELECT 
        mp.id_Medicacion_Paciente, 
        m.nombre AS Medicamento, 
        mp.fecha_Preesctrito,
        ROW_NUMBER() OVER (ORDER BY mp.fecha_Preesctrito DESC) AS rn  
    FROM Medicacion_Paciente mp
    INNER JOIN Medicamento m ON mp.id_Medicamento = m.id_Medicamento
    INNER JOIN Cita c ON mp.id_Cita = c.id_Cita  
    WHERE c.id_Paciente = @IdPaciente  
),
EnfermedadMayorFase AS (
    SELECT 
        ed.id_Enfermedad, 
        e.nombre AS Enfermedad, 
        ed.fase_Enfermedad,
        ROW_NUMBER() OVER (ORDER BY 
            CASE 
                WHEN ed.fase_Enfermedad = 'Fase 1' THEN 1
                WHEN ed.fase_Enfermedad = 'Fase 2' THEN 2
                WHEN ed.fase_Enfermedad = 'Fase 3' THEN 3
                WHEN ed.fase_Enfermedad = 'Fase 4' THEN 4
                ELSE 0  
            END DESC) AS rn  
    FROM Enfermedad_Diagnostico ed
    INNER JOIN Enfermedad e ON ed.id_Enfermedad = e.id_Enfermedad
    INNER JOIN Cita c ON ed.id_Cita = c.id_Cita
    WHERE c.id_Paciente = @IdPaciente  
)
SELECT 
    ump.Medicamento,
    emf.Enfermedad,
    emf.fase_Enfermedad,
    p.peso,      
    p.estatura,
    p.id_Paciente
FROM UltimaMedicacionPreescrita ump
INNER JOIN EnfermedadMayorFase emf ON ump.rn = 1 AND emf.rn = 1
INNER JOIN Paciente p ON p.id_Paciente = @IdPaciente;

END