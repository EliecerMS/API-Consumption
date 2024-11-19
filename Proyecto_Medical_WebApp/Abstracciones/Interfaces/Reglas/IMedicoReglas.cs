using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.Reglas
{
    public interface IMedicoReglas
    {
        public PacientesMedicoBD DarFormatoPacienteMedico(PacientesMedicoBD pacienteMedico);

        public DetallesPaciente DarFomartoDetallesPaciente(DetallesPaciente detallesPaciente);

        public PacientesPadecimientosBD DarFomartoPacienteYPadecimiento(PacientesPadecimientosBD pacienteYPadecimiento);
    }
}
