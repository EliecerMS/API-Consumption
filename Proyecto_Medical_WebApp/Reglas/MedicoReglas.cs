using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using System.Globalization;

namespace Reglas
{
    public class MedicoReglas : IMedicoReglas
    {
        public Medico_DetallesPaciente DarFomartoDetallesPaciente(Medico_DetallesPaciente detallesPaciente)
        {
            detallesPaciente.Enfermedad = detallesPaciente.Enfermedad.ToUpper();
            detallesPaciente.Medicamento = detallesPaciente.Medicamento.ToUpper();
            detallesPaciente.fase_Enfermedad = detallesPaciente.fase_Enfermedad.ToUpper();
            return detallesPaciente;
        }

        public EnfermedadDiagnosticoBD DarFomartoEnfermedadDiagnostico(EnfermedadDiagnosticoBD enfermedadDiagnostico)
        {
            enfermedadDiagnostico.nombre = enfermedadDiagnostico.nombre.ToUpper();
            return enfermedadDiagnostico;
        }

        

        public PacientesPadecimientosBD DarFomartoPacienteYPadecimiento(PacientesPadecimientosBD pacienteYPadecimiento)
        {
            pacienteYPadecimiento.NombreCompletoPaciente = pacienteYPadecimiento.NombreCompletoPaciente.ToUpper();
            pacienteYPadecimiento.Enfermedad = pacienteYPadecimiento.Enfermedad.ToUpper();
            return pacienteYPadecimiento;

        }

        public PacientesMedicoBD DarFormatoPacienteMedico(PacientesMedicoBD pacienteMedico)
        {
            pacienteMedico.nombre = pacienteMedico.nombre.ToUpper();

            DateTime fechaCitaDiaHora = DateTime.ParseExact(pacienteMedico.fecha_Cita, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            DateOnly fechaCitaSoloFecha = DateOnly.FromDateTime(fechaCitaDiaHora);
            string fechaCitaAString = fechaCitaSoloFecha.ToString("yyyy-MM-dd");
            pacienteMedico.fecha_Cita = fechaCitaAString;
            return pacienteMedico;
        }

        public MedicamentoBD DarFomartoDetalleMedicamento(MedicamentoBD medicamento)
        {
            medicamento.nombre = medicamento.nombre.ToUpper();
            DateTime fechaCitaDiaHora = DateTime.ParseExact(medicamento.fecha_Preesctrito, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            DateOnly fechaCitaSoloFecha = DateOnly.FromDateTime(fechaCitaDiaHora);
            string fechaCitaAString = fechaCitaSoloFecha.ToString("yyyy-MM-dd");
            medicamento.fecha_Preesctrito = fechaCitaAString;
            return medicamento;
        }

        public PacienteMedicamentoBD DarFormatoPacienteMedicamento(PacienteMedicamentoBD pacienteMedicamento)
        {
            pacienteMedicamento.NombrePaciente = pacienteMedicamento.NombrePaciente.ToUpper();
            pacienteMedicamento.NombreMedicamento = pacienteMedicamento.NombreMedicamento.ToUpper();
            return pacienteMedicamento;
        }
    }

}
