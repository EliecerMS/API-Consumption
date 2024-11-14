using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;

namespace Reglas
{
    public class MedicoReglas : IMedicoReglas
    {
        public PacientesMedicoBD DarFormatoNombre(PacientesMedicoBD pacienteMedico)
        {
            pacienteMedico.nombre = pacienteMedico.nombre.ToUpper();
            return pacienteMedico;
        }
    }
}
