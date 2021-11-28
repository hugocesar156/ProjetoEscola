using Microsoft.AspNetCore.Mvc;
using ProjetoEscola.Global;
using ProjetoEscola.Models;
using ProjetoEscola.Repositories;
using System.Threading.Tasks;

namespace ProjetoEscola.Controllers
{
    public class TurmaController : Controller
    {
        public IActionResult Cadastro()
        {
            return View(new Turma());
        }

        public async Task<PartialViewResult> ValidarCadastro(Turma turma)
        {
            if (turma.Ensino == (byte)Ensino.Medio && turma.AnoEnsino > 3)
                ModelState.AddModelError(nameof(turma.AnoEnsino), Biblioteca.CAMPO_INVALIDO);

            if (ModelState.IsValid)
            {
                if (await TurmaR.Registrar(turma))
                {
                    ModelState.Clear();

                    ViewBag.Notificacao = new Notificacao
                    {
                        Tipo = Tipo.Sucesso,
                        Mensagem = Notificacao.CADASTRO_SUCESSO
                    };

                    return PartialView(nameof(Cadastro), new Turma());
                }

                ViewBag.Notificacao = new Notificacao
                {
                    Tipo = Tipo.Falha,
                    Mensagem = Notificacao.CADASTRO_FALHA
                };
            }

            return PartialView(nameof(Cadastro), turma);
        }
    }
}
