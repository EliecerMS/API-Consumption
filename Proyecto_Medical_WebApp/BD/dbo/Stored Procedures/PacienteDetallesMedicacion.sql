
CREATE PROCEDURE [dbo].[PacienteDetallesMedicacion]
 @IdMedicacionPaciente int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		CONCAT(m.nombre, ' ', m.primer_Apellido, ' ', m.segundo_Apellido) AS NombreDoctor,
		m.email AS EmailDoctor,
		e.nombre AS NombrePadecimiento,
		med.nombre AS NombreMedicacion,
		mp.dosis AS Dosis,
		mp.intrucciones AS Intrucciones,
		mp.fecha_Preesctrito AS FechaPreescripcion
	FROM 
			Medicacion_Paciente mp
		JOIN 
			Cita c ON mp.id_Cita = c.id_Cita
		JOIN 
			Medico m ON c.id_Medico = m.id_Medico
		JOIN 
			Enfermedad_Diagnostico ed ON c.id_Cita = ed.id_Cita
		JOIN 
			Enfermedad e ON ed.id_Enfermedad = e.id_Enfermedad
		JOIN 
			Medicamento med ON mp.id_Medicamento = med.id_Medicamento
		WHERE 
			mp.id_Medicacion_Paciente = @IdMedicacionPaciente
		ORDER BY 
			mp.fecha_Preesctrito;
END