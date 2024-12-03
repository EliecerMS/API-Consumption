using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reglas;
using System.Text.Json;

namespace Web.Pages.Cuenta
{
    public class RegistroModel : PageModel
    {
        [BindProperty]
        public Usuario usuario { get; set; } = default!;
        private IConfiguracion _configuracion;

        public RegistroModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
            var hash=Autenticacion.GenerarHash(usuario.Password);
            var hashString = Autenticacion.ObtenerHash(hash);
            usuario.PasswordHash = hashString;
            string endpoint = _configuracion.ObtenerMetodo("ApiEndPointsSeguridad", "Registro");
            var cliente = new HttpClient();
            var respuesta = await cliente.PostAsJsonAsync<UsuarioBase>(endpoint, usuario);
            var resultado = await respuesta.Content.ReadAsStringAsync();
            var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var Id = JsonSerializer.Deserialize<Guid>(resultado, opciones);
            respuesta.EnsureSuccessStatusCode();
            return RedirectToPage("../index");
        }
    }
}
