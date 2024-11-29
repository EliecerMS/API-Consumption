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
            pacienteDetallesMedicacion.Intrucciones = pacienteDetallesMedicacion.Intrucciones.ToUpper();
            pacienteDetallesMedicacion.Dosis = pacienteDetallesMedicacion.Dosis.ToUpper();


            DateTime fechaPreescripcionDiaHora = DateTime.ParseExact(pacienteDetallesMedicacion.FechaPreescripcion, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            DateOnly fechaPreescripcionSoloFecha = DateOnly.FromDateTime(fechaPreescripcionDiaHora);
            string fechaPreescripcionAString = fechaPreescripcionSoloFecha.ToString("yyyy-MM-dd");
            pacienteDetallesMedicacion.FechaPreescripcion = fechaPreescripcionAString;

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
    }
}
