using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.Reglas
{
    public interface IMedicamentoReglas
    {
        public MedicamentoBD DarFormatoNombre(MedicamentoBD medicamento);
    }
}
