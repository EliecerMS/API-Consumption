using Microsoft.AspNetCore.Mvc;

namespace Abstracciones.Interfaces.API
{
    public interface IMedicoController
    {
        Task<IActionResult> ObtenerPacientesMedico(int medicoId);
    }
}
