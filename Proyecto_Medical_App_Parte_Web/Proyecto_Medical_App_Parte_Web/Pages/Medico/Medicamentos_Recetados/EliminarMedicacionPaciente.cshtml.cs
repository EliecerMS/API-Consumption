using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Text.Json;

namespace Proyecto_Medical_App_Parte_Web.Pages.Medico.Medicamentos_Recetados
{
    public class EliminarMedicacionPacienteModel : PageModel
    {
        private IConfiguracion _configuracion;

        [BindProperty]
        public MedicacionPacienteMapping medicacionPaciente { get; set; } = default!;

        public EliminarMedicacionPacienteModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }
        public async Task<ActionResult> OnGet(int? id)
        {
            if (id == null)
                return NotFound();
            string endpoint = _configuracion.ObtenerMetodo("ObtenerDetalleMedicacionPaciente");
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, string.Format(endpoint, id));
            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();

            if (respuesta.StatusCode == HttpStatusCode.OK)
            {
                var resultado = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                medicacionPaciente = JsonSerializer.Deserialize<MedicacionPacienteMapping>(resultado, opciones);

            }

            return Page();

        }

        public async Task<ActionResult> OnPost(int? id)
        {

            if (id == null)
                return NotFound();



            string endpoint = _configuracion.ObtenerMetodo("EliminarMedicacion");
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Delete, string.Format(endpoint, id));
            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();

            return RedirectToPage("./Index");

        }
    }
}
