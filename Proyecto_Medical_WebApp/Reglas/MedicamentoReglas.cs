using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;

namespace Reglas
{
    public class MedicamentoReglas : IMedicamentoReglas
    {
        public MedicamentoBD DarFormatoNombre(MedicamentoBD medicamento)
        {
            medicamento.Nombre = medicamento.Nombre.ToUpper();
            return medicamento;
        }


    }
}
