using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjetoEscolaAPI.Global;
using ProjetoEscolaAPI.Models.Aluno;
using ProjetoEscolaAPI.Repositories;
using System;

namespace ProjetoEscolaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly AlunoR _reposAluno;

        public AlunoController(AlunoR reposAluno)
        {
            _reposAluno = reposAluno;
        }

        [HttpPost]
        public ContentResult Post([FromBody] JObject dados)
        {
            var aluno = JsonConvert.DeserializeObject<Aluno>(dados.ToString());
            aluno.DataCriacao = DateTime.Now;

            if (_reposAluno.Registrar(aluno))
                return new ContentResult { StatusCode = (int)Biblioteca.StatusCode.Success };

            return new ContentResult { StatusCode = (int)Biblioteca.StatusCode.BadRequest };
        }
    }
}
