using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Text.Json;

namespace Proyecto_Medical_App_Parte_Web.Pages.Medico.Pacientes
{
    public class DetallesPacienteModel : PageModel
    {
        private IConfiguracion _configuracion;

        [BindProperty]
        public Medico_DetallesPaciente paciente { get; set; } = default!;

        [BindProperty]
        public Medico_PesoAltura modeloEditarPesoAltura { get; set; } = default!;

        public DetallesPacienteModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }
        public async Task<ActionResult> OnGet(Guid? id)
        {
            if (id == null)
                return NotFound();
            string endpoint = _configuracion.ObtenerMetodo("ObtenerDetallesPaciente");
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, string.Format(endpoint, id));
            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();

            if (respuesta.StatusCode == HttpStatusCode.OK)
            {
                var resultado = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                paciente = JsonSerializer.Deserialize<Medico_DetallesPaciente>(resultado, opciones);

            }

            return Page();

        }

        public async Task<ActionResult> OnPost()
        {

            if (paciente.id_Paciente == null)
                return NotFound();

            if (!ModelState.IsValid)
                return Page();



            Medico_PesoAltura nuevoPesoAltura = new Medico_PesoAltura
            {
                peso = paciente.peso,
                estatura = paciente.estatura
            };


            string endpoint = _configuracion.ObtenerMetodo("EditarPesoAltura");
            var cliente = new HttpClient();
            var respuesta = await cliente.PutAsJsonAsync<Medico_PesoAltura>(string.Format(endpoint, paciente.id_Paciente), nuevoPesoAltura);
            respuesta.EnsureSuccessStatusCode();

            return RedirectToPage("./Index");

        }
    }
}
