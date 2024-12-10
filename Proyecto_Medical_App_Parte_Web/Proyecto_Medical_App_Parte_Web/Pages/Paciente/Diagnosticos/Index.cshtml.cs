using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Text.Json;

namespace Proyecto_Medical_App_Parte_Web.Pages.Paciente.Diagnosticos
{
    public class IndexModel : PageModel
    {
        private IConfiguracion _configuracion;

        public List<PacientePadecimientosBD> padecimientos { get; set; } = default!;

        public IndexModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        public async Task OnGetAsync()
        {
            string endpoint = _configuracion.ObtenerMetodo("MostrarListaPadecimientosPaciente");
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, string.Format(endpoint, "C4133D19-EE29-4E71-9D98-50F02475BBD2")); // probando con id de paciente

            try
            {
                var respuesta = await cliente.SendAsync(solicitud);
                respuesta.EnsureSuccessStatusCode();

                if (respuesta.StatusCode == HttpStatusCode.OK)
                {
                    var resultado = await respuesta.Content.ReadAsStringAsync();
                    var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    padecimientos = JsonSerializer.Deserialize<List<PacientePadecimientosBD>>(resultado, opciones) ?? new List<PacientePadecimientosBD>();
                }
            }
            catch (HttpRequestException ex)
            {
                padecimientos = new List<PacientePadecimientosBD>();
            }
        }
    }
}
