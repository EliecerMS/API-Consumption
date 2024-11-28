using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;


namespace Abstracciones.Interfaces.API
{
    public interface IMedicamentoController
    {
        Task<IActionResult> Obtener();
        Task<IActionResult> ObtenerPorId(Guid Id_Medicamento);
    }
}
