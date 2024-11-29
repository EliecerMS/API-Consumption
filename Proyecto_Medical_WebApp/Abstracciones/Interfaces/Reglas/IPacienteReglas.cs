using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.Reglas
{
    public interface IPacienteReglas
    {
        public Paciente_DetallesMedicacion DarFomartoPacienteDetallesMedicacion(Paciente_DetallesMedicacion pacienteDetallesMedicacion);

        public Paciente_DetallesPadecimiento DarFomartoPacienteDetallesPadecimiento(Paciente_DetallesPadecimiento pacienteDetallesPadecimiento);
    }
}
