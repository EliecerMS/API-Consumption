using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;


namespace Abstracciones.Interfaces.API
{
    public interface IEnfermedadDiagnosticoController
    {
        Task<IActionResult> Obtener();
        Task<IActionResult> ObtenerPorId(Guid Id_EnfermedadDiagnosticoBD);

    }
}
