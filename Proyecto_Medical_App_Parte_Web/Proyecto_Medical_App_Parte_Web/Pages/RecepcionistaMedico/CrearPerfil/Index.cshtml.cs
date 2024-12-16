using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Proyecto_Medical_App_Parte_Web.Pages.RecepcionistaMedico.CrearPerfil
{
    public class IndexModel : PageModel
    {
        private IConfiguracion _configuracion;
        [BindProperty]
        public Persona persona { get; set; } = default!;
        public IndexModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
            persona = new Persona();
            persona.id_Persona = Guid.NewGuid();
        }
        public async Task<ActionResult> OnGet()
        {

            return Page();
        }
        public async Task<ActionResult> OnPost()
        {

            string endpoint = _configuracion.ObtenerMetodo("CrearPerfil");
            var cliente = new HttpClient();
            var respuesta = await cliente.PostAsJsonAsync(endpoint, persona);
            respuesta.EnsureSuccessStatusCode();
            return RedirectToPage("./Index");
        }
    }
}
