using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.Flujo
{
    public interface IFormatoHelper
    {
        //aca empiezan los del medico
        IEnumerable<PacientesMedicoBD> DarFormatoListaPacientes(IEnumerable<PacientesMedicoBD> pacientesSinFormato);

        public Medico_DetallesPaciente DarFormatoDetallesPaciente(Medico_DetallesPaciente detallesPaciente);

        IEnumerable<PacientesPadecimientosBD> DarFormatoListaPacientesYPadecimientos(IEnumerable<PacientesPadecimientosBD> pacientesYPadecimientosSinFormato);
        //IEnumerable<MedicamentoBD> DarFormatoListaMedicamentos(IEnumerable<MedicamentoBD> medicamentos);

        public MedicamentoBD DarFormatoDetalleMedicamento(MedicamentoBD medicamentoSinformato);
        public EnfermedadDiagnosticoBD DarFormatoEnfermedadDiagnostico(EnfermedadDiagnosticoBD enfermedadDiagnosticoSinFormato);


        //del paciente
        public Paciente_DetallesMedicacion DarFomartoPacienteDetallesMedicacion(Paciente_DetallesMedicacion pacienteDetallesMedicacion);

        public Paciente_DetallesPadecimiento DarFomartoPacienteDetallesPadecimiento(Paciente_DetallesPadecimiento pacienteDetallesPadecimiento);
       
    }
}
