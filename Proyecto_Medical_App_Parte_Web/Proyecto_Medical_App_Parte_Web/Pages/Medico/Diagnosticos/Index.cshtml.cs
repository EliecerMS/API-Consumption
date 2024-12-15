using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Text.Json;

namespace Proyecto_Medical_App_Parte_Web.Pages.Medico.Diagnosticos
{
    public class IndexModel : PageModel
    {
        private IConfiguracion _configuracion;

        public List<PacientesPadecimientosBD> pacientesDiagnosticos { get; set; } = default!;

        public IndexModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        public async Task OnGetAsync()
        {
            string endpoint = _configuracion.ObtenerMetodo("MostrarListaPacientesYPadecimientos");
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, string.Format(endpoint, "B6D8D3F0-3C94-47F7-A80D-FD46B8A1D1C0")); // probando con ids de medico

            try
            {
                var respuesta = await cliente.SendAsync(solicitud);
                respuesta.EnsureSuccessStatusCode();

                if (respuesta.StatusCode == HttpStatusCode.OK)
                {
                    var resultado = await respuesta.Content.ReadAsStringAsync();
                    var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    pacientesDiagnosticos = JsonSerializer.Deserialize<List<PacientesPadecimientosBD>>(resultado, opciones) ?? new List<PacientesPadecimientosBD>();
                }
            }
            catch (HttpRequestException ex)
            {
                pacientesDiagnosticos = new List<PacientesPadecimientosBD>();
            }
        }
    }
}
