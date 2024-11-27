using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.Flujo
{
    public interface IFormatoHelper
    {

        IEnumerable<PacientesMedicoBD> DarFormatoListaPacientes(IEnumerable<PacientesMedicoBD> pacientesSinFormato);

        public DetallesPaciente DarFormatoDetallesPaciente(DetallesPaciente detallesPaciente);

        IEnumerable<PacientesPadecimientosBD> DarFormatoListaPacientesYPadecimientos(IEnumerable<PacientesPadecimientosBD> pacientesYPadecimientosSinFormato);
        IEnumerable<MedicamentoBD> DarFormatoListaMedicamentos(IEnumerable<MedicamentoBD> medicamentos);
        Medicamento DarFormatoMedicamento(MedicamentoBD medicamento);

    }
}
