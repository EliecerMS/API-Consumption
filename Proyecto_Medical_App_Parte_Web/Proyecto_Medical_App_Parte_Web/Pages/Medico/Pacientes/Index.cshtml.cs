using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Text.Json;

namespace Proyecto_Medical_App_Parte_Web.Pages.Medico.Pacientes
{
    public class IndexModel : PageModel
    {
        private IConfiguracion _configuracion;

        public List<PacientesMedicoBD> pacientes { get; set; } = default!;

        public IndexModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        public async Task OnGetAsync()
        {
            string endpoint = _configuracion.ObtenerMetodo("MostrarListaPacientes");
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, string.Format(endpoint, "E9D88A88-0FB1-4A95-A4BB-A5E1DBA7D30E")); // probando con ids de medico

            try
            {
                var respuesta = await cliente.SendAsync(solicitud);
                respuesta.EnsureSuccessStatusCode();

                if (respuesta.StatusCode == HttpStatusCode.OK)
                {
                    var resultado = await respuesta.Content.ReadAsStringAsync();
                    var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    pacientes = JsonSerializer.Deserialize<List<PacientesMedicoBD>>(resultado, opciones) ?? new List<PacientesMedicoBD>();
                }
            }
            catch (HttpRequestException ex)
            {
                pacientes = new List<PacientesMedicoBD>();
            }
        }
    }
}
