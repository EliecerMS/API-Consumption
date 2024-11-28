using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.Flujo
{
    public interface IFormatoHelper
    {
        //aca empiezan los del medico
        IEnumerable<PacientesMedicoBD> DarFormatoListaPacientes(IEnumerable<PacientesMedicoBD> pacientesSinFormato);

        public DetallesPaciente DarFormatoDetallesPaciente(DetallesPaciente detallesPaciente);

        IEnumerable<PacientesPadecimientosBD> DarFormatoListaPacientesYPadecimientos(IEnumerable<PacientesPadecimientosBD> pacientesYPadecimientosSinFormato);
        IEnumerable<MedicamentoBD> DarFormatoListaMedicamentos(IEnumerable<MedicamentoBD> medicamentos);
        Medicamento DarFormatoMedicamento(MedicamentoBD medicamento);

        //del paciente
        public PacienteDetallesMedicacion DarFomartoPacienteDetallesMedicacion(PacienteDetallesMedicacion pacienteDetallesMedicacion);

        public PacienteDetallesPadecimiento DarFomartoPacienteDetallesPadecimiento(PacienteDetallesPadecimiento pacienteDetallesPadecimiento);

    }
}
