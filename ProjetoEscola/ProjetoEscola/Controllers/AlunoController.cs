using Microsoft.AspNetCore.Mvc;
using ProjetoEscola.Models;
using ProjetoEscola.Models.Aluno;
using ProjetoEscola.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEscola.Controllers
{
    public class AlunoController : Controller
    {
        public IActionResult Cadastro()
        {
            ViewBag.Responsavel = new List<Responsavel>
            {
                new Responsavel
                {
                    Id = 1,
                    Nome = "Responsável 1"
                },
                new Responsavel
                {
                    Id = 2,
                    Nome = "Responsável 2"
                },
                new Responsavel
                {
                    Id = 3,
                    Nome = "Responsável 3"
                },
                new Responsavel
                {
                    Id = 4,
                    Nome = "Responsável 4"
                },
            };

            return View(new Aluno { Endereco = new Endereco() } );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<PartialViewResult> ValidarCadastro(Aluno aluno)
        {
            ViewBag.Responsavel = new List<Responsavel>
            {
                new Responsavel
                {
                    Id = 1,
                    Nome = "Responsável 1"
                },
                new Responsavel
                {
                    Id = 2,
                    Nome = "Responsável 2"
                },
                new Responsavel
                {
                    Id = 3,
                    Nome = "Responsável 3"
                },
                new Responsavel
                {
                    Id = 4,
                    Nome = "Responsável 4"
                },
            };

            if (ModelState.IsValid)
            {
                if (await AlunoR.Registrar(aluno))
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

            return PartialView(nameof(Cadastro), aluno);
        }
    }
}
