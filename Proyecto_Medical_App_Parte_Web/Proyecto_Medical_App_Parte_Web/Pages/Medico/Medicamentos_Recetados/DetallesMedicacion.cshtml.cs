using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Text.Json;

namespace Proyecto_Medical_App_Parte_Web.Pages.Medico.Medicamentos_Recetados
{
    public class DetallesMedicacionModel : PageModel
    {
        private IConfiguracion _configuracion;

        [BindProperty]
        public MedicamentoBD detalleMedicamento { get; set; } = default!;
        public DetallesMedicacionModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }


        public async Task<ActionResult> OnGet(int? id, Guid? id2)
        {
            if (id == null || id2 == null)
                return NotFound();

            string endpoint = _configuracion.ObtenerMetodo("DetalleMedicamento");
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, string.Format(endpoint, id, id2));
            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();

            if (respuesta.StatusCode == HttpStatusCode.OK)
            {
                var resultado = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                detalleMedicamento = JsonSerializer.Deserialize<MedicamentoBD>(resultado, opciones);

            }

            return Page();

        }
    }
    
}
