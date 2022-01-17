using Microsoft.AspNetCore.Mvc;
using ProjetoEscola.Global;
using ProjetoEscola.Models;
using ProjetoEscola.Repositories;
using System.Threading.Tasks;

namespace ProjetoEscola.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Login()
        {
            return View(new Usuario());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ValidarLogin(Usuario acesso)
        {
            var usuario = await UsuarioR.ValidarAcesso(acesso.Email, acesso.Senha);

            if (usuario != null)
            {
                return RedirectToAction("Inicio", "Home");
            }

            ModelState.AddModelError(nameof(acesso.Email), Biblioteca.USUARIO_INVALIDO);
            return View("Login", acesso);
        }

        public async Task<IActionResult> Buscar() 
        {
            await UsuarioR.Buscar("hugo@email.com");
            return Ok();
        }
    }
}
