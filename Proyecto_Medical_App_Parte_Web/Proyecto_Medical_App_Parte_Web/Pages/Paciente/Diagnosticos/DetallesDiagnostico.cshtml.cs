using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Text.Json;

namespace Proyecto_Medical_App_Parte_Web.Pages.Paciente.Diagnosticos
{
    public class DetallesDiagnosticoModel : PageModel
    {
        private IConfiguracion _configuracion;

        [BindProperty]
        public Paciente_DetallesPadecimiento detallePadecimiento { get; set; } = default!;

        public DetallesDiagnosticoModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }
        public async Task<ActionResult> OnGet(int? id, int? idEnferDiagnostico)
        {
            if (id == null || idEnferDiagnostico == null)
                return NotFound();

            string endpoint = _configuracion.ObtenerMetodo("MostrarDetallesDelPadecimientoPaciente");
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, string.Format(endpoint, id, idEnferDiagnostico));
            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();

            if (respuesta.StatusCode == HttpStatusCode.OK)
            {
                var resultado = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                detallePadecimiento = JsonSerializer.Deserialize<Paciente_DetallesPadecimiento>(resultado, opciones);

            }

            return Page();

        }
    }
}
