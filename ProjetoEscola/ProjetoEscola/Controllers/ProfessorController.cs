using Microsoft.AspNetCore.Mvc;
using ProjetoEscola.Global;
using ProjetoEscola.Models;
using ProjetoEscola.Repositories;
using System.Threading.Tasks;

namespace ProjetoEscola.Controllers
{
    public class ProfessorController : Controller
    {
        public IActionResult Cadastro()
        {
            return View(new Professor());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<PartialViewResult> ValidarCadastro(Professor professor)
        {
            if (ModelState.IsValid)
            {
                if (await UsuarioR.Buscar(professor.Usuario.Email) != null)
                {
                    ModelState.AddModelError("Usuario.Email", Biblioteca.EMAIL_EM_USO);
                    return PartialView(nameof(Cadastro), professor);
                }
                    
                if (await ProfessorR.Registrar(professor))
                {
                    ModelState.Clear();

                    ViewBag.Notificacao = new Notificacao
                    {
                        Tipo = Tipo.Sucesso,
                        Mensagem = Notificacao.CADASTRO_SUCESSO
                    };

                    return PartialView(nameof(Cadastro), new Professor());
                }

                ViewBag.Notificacao = new Notificacao
                {
                    Tipo = Tipo.Falha,
                    Mensagem = Notificacao.CADASTRO_FALHA
                };
            }

            return PartialView(nameof(Cadastro), professor);
        }
    }
}
