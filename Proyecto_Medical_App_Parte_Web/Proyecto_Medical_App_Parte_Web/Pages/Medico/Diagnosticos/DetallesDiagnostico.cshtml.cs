using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Text.Json;

namespace Proyecto_Medical_App_Parte_Web.Pages.Medico.Diagnosticos
{
    public class DetallesDiagnosticoModel : PageModel
    {
        private IConfiguracion _configuracion;

        [BindProperty]
        public EnfermedadDiagnosticoBD diagnostico { get; set; } = default!;



        public DetallesDiagnosticoModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }
        public async Task<ActionResult> OnGet(int? id)
        {
            if (id == null)
                return NotFound();
            string endpoint = _configuracion.ObtenerMetodo("ObtenerEnfermedadDiagnostico");
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, string.Format(endpoint, id));
            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();

            if (respuesta.StatusCode == HttpStatusCode.OK)
            {
                var resultado = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                diagnostico = JsonSerializer.Deserialize<EnfermedadDiagnosticoBD>(resultado, opciones);
                diagnostico.id_EnferDiagnostico = (int)id;

            }

            return Page();

        }

        public async Task<ActionResult> OnPost()
        {

            if (diagnostico.id_EnferDiagnostico == null)
                return NotFound();

            if (!ModelState.IsValid)
                return Page();



            Medico_EnfermedadDiagnostico nuevoDiagnostico = new Medico_EnfermedadDiagnostico
            {
                nombre = diagnostico.nombre,
                notas_Diagnostico = diagnostico.notas_Diagnostico,
                fase_Enfermedad = diagnostico.fase_Enfermedad,
            };


            string endpoint = _configuracion.ObtenerMetodo("ActualizarDiagnostico");
            var cliente = new HttpClient();
            var respuesta = await cliente.PutAsJsonAsync<Medico_EnfermedadDiagnostico>(string.Format(endpoint, diagnostico.id_EnferDiagnostico), nuevoDiagnostico);
            respuesta.EnsureSuccessStatusCode();

            return RedirectToPage("./Index");

        }
    }
    }

