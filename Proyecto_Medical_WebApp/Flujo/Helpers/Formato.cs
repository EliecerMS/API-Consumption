using Abstracciones.Interfaces.Flujo;
using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;

namespace Flujo.Helpers
{
    public class Formato : IFormatoHelper
    {
        private IMedicoReglas _medicoReglas;
        private IMedicamentoReglas _medicamentoReglas;
       


        public Formato(IMedicoReglas medicoReglas)
        {
            _medicoReglas = medicoReglas;
        }

        public DetallesPaciente DarFormatoDetallesPaciente(DetallesPaciente detallesPaciente)
        {
            if (detallesPaciente == null)
                return null;
            return _medicoReglas.DarFomartoDetallesPaciente(detallesPaciente);
        }

        public IEnumerable<PacientesMedicoBD> DarFormatoListaPacientes(IEnumerable<PacientesMedicoBD> pacientesSinFormato)
        {
            List<PacientesMedicoBD> resultadoConFormato = new List<PacientesMedicoBD>();

            foreach (var paciente in pacientesSinFormato)
            {
                resultadoConFormato.Add(_medicoReglas.DarFormatoPacienteMedico(paciente));

            }
            return resultadoConFormato;
        }

        public IEnumerable<PacientesPadecimientosBD> DarFormatoListaPacientesYPadecimientos(IEnumerable<PacientesPadecimientosBD> pacientesYPadecimientosSinFormato)
        {
            List<PacientesPadecimientosBD> resultadoConFormato = new List<PacientesPadecimientosBD>();

            foreach (var pacienteYPadecimiento in pacientesYPadecimientosSinFormato)
            {
                resultadoConFormato.Add(_medicoReglas.DarFomartoPacienteYPadecimiento(pacienteYPadecimiento));

            }
            return resultadoConFormato;
        }
        public IEnumerable<MedicamentoBD> DarFormatoListaMedicamentos(IEnumerable<MedicamentoBD> medicamentosSinFormato)
        {
            List<MedicamentoBD> resultadoConFormato = new List<MedicamentoBD>();

            foreach (var medicamento in medicamentosSinFormato)
            {
                resultadoConFormato.Add(_medicamentoReglas.DarFormatoNombre(medicamento));

            }
            return resultadoConFormato;
        }

        public Medicamento DarFormatoMedicamento(MedicamentoBD medicamento)
        {
            if (medicamento == null)
                return null;
            return _medicamentoReglas.DarFormatoNombre(medicamento);
        }
    }
    
}
