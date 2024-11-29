using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.Reglas
{
    public interface IMedicoReglas
    {
        public PacientesMedicoBD DarFormatoPacienteMedico(PacientesMedicoBD pacienteMedico);

        public Medico_DetallesPaciente DarFomartoDetallesPaciente(Medico_DetallesPaciente detallesPaciente);

        public PacientesPadecimientosBD DarFomartoPacienteYPadecimiento(PacientesPadecimientosBD pacienteYPadecimiento);
    }
}
