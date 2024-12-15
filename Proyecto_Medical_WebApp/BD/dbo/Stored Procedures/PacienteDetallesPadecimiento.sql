CREATE PROCEDURE [dbo].[PacienteDetallesPadecimiento]
    @IdEnferDiagnostico int,
    @IdCita int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT 
    CONCAT(p.nombre, ' ', p.primer_Apellido, ' ', p.segundo_Apellido) AS NombreDoctor,
    p.email AS EmailDoctor,
    E.nombre AS NombreEnfermedad,
    MP.dosis AS DosisMedicacion,
    MP.intrucciones AS InstruccionesMedicamento,
    ED.notas_Diagnostico AS NotasDiagnostico,
    ED.fase_Enfermedad AS FaseEnfermedad
FROM 
    Enfermedad_Diagnostico ED
INNER JOIN 
    Enfermedad E ON ED.id_Enfermedad = E.id_Enfermedad  
INNER JOIN 
    Cita C ON ED.id_Cita = C.id_Cita  
INNER JOIN 
    Medico M ON C.id_Medico = M.id_Medico  
INNER JOIN 
    Persona p ON M.id_Medico = p.id_Persona  
LEFT JOIN 
    Medicacion_Paciente MP ON ED.id_Cita = MP.id_Cita  
WHERE 
    ED.id_EnferDiagnostico = @IdEnferDiagnostico  
    AND C.id_Cita = @IdCita;  

END