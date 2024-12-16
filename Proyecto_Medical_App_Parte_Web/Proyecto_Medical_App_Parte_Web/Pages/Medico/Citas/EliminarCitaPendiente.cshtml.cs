using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Text.Json;

namespace Proyecto_Medical_App_Parte_Web.Pages.Medico.Citas
{
    public class EliminarCitaPendienteModel : PageModel
    {
        private IConfiguracion _configuracion;

        [BindProperty]
        public CitaMapping cita { get; set; } = default!;

        public EliminarCitaPendienteModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }
        public async Task<ActionResult> OnGet(int? idCita)
        {
            if (idCita == null)
                return NotFound();
            string endpoint = _configuracion.ObtenerMetodo("ObtenerCita");
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, string.Format(endpoint, idCita));
            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();

            if (respuesta.StatusCode == HttpStatusCode.OK)
            {
                var resultado = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                cita = JsonSerializer.Deserialize<CitaMapping>(resultado, opciones);

            }

            return Page();

        }

        public async Task<ActionResult> OnPost(int? idCita)
        {

            if (idCita == null)
                return NotFound();



            string endpoint = _configuracion.ObtenerMetodo("EliminarCitaPendiente");
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Delete, string.Format(endpoint, idCita));
            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();

            return RedirectToPage("./Index");

        }

    }
}
