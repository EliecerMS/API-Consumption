using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using System.Globalization;

namespace Reglas
{
    public class PacienteReglas : IPacienteReglas
    {
        public Paciente_DetallesMedicacion DarFomartoPacienteDetallesMedicacion(Paciente_DetallesMedicacion pacienteDetallesMedicacion)
        {
            pacienteDetallesMedicacion.NombreDoctor = pacienteDetallesMedicacion.NombreDoctor.ToUpper();
            pacienteDetallesMedicacion.NombrePadecimiento = pacienteDetallesMedicacion.NombrePadecimiento.ToUpper();
            pacienteDetallesMedicacion.Instrucciones = pacienteDetallesMedicacion.Instrucciones.ToUpper();
            pacienteDetallesMedicacion.Dosis = pacienteDetallesMedicacion.Dosis.ToUpper();
            pacienteDetallesMedicacion.NombreMedicacion = pacienteDetallesMedicacion.NombreMedicacion.ToUpper();


            DateTime fechaPreescripcionDiaHora = DateTime.ParseExact(pacienteDetallesMedicacion.FechaPrescripcion, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            DateOnly fechaPreescripcionSoloFecha = DateOnly.FromDateTime(fechaPreescripcionDiaHora);
            string fechaPreescripcionAString = fechaPreescripcionSoloFecha.ToString("yyyy-MM-dd");
            pacienteDetallesMedicacion.FechaPrescripcion = fechaPreescripcionAString;

            return pacienteDetallesMedicacion;

        }

        public Paciente_DetallesPadecimiento DarFomartoPacienteDetallesPadecimiento(Paciente_DetallesPadecimiento pacienteDetallesPadecimiento)
        {
            pacienteDetallesPadecimiento.NotasDiagnostico = pacienteDetallesPadecimiento.NotasDiagnostico?.ToUpper();
            pacienteDetallesPadecimiento.InstruccionesMedicamento = pacienteDetallesPadecimiento.InstruccionesMedicamento?.ToUpper();
            pacienteDetallesPadecimiento.DosisMedicacion = pacienteDetallesPadecimiento.DosisMedicacion?.ToUpper();
            pacienteDetallesPadecimiento.NombreEnfermedad = pacienteDetallesPadecimiento.NombreEnfermedad?.ToUpper();
            pacienteDetallesPadecimiento.FaseEnfermedad = pacienteDetallesPadecimiento.FaseEnfermedad?.ToUpper();
            pacienteDetallesPadecimiento.NombreDoctor = pacienteDetallesPadecimiento.NombreDoctor?.ToUpper();

            return pacienteDetallesPadecimiento;
        }

        public PacientePadecimientosBD DarFomartoPacientePadecimiento(PacientePadecimientosBD pacientePadecimiento)// agregado y probado por eliecer
        {
            pacientePadecimiento.NombreEnfermedad = pacientePadecimiento.NombreEnfermedad.ToUpper();
            pacientePadecimiento.MotivoCita = pacientePadecimiento.MotivoCita.ToUpper();

            DateTime fechaDiagnosticoDiaHora = DateTime.ParseExact(pacientePadecimiento.fecha_Diagnostico, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            DateOnly fechaDiagnosticoSoloFecha = DateOnly.FromDateTime(fechaDiagnosticoDiaHora);
            string fechaDiagnosticoAString = fechaDiagnosticoSoloFecha.ToString("yyyy-MM-dd");
            pacientePadecimiento.fecha_Diagnostico = fechaDiagnosticoAString;

            return pacientePadecimiento;
        }
    }
}
