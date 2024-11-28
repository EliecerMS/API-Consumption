using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.Reglas
{
    public interface IPacienteReglas
    {
        public PacienteDetallesMedicacion DarFomartoPacienteDetallesMedicacion(PacienteDetallesMedicacion pacienteDetallesMedicacion);

        public PacienteDetallesPadecimiento DarFomartoPacienteDetallesPadecimiento(PacienteDetallesPadecimiento pacienteDetallesPadecimiento);
    }
}
