using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjetoEscolaAPI.Global;
using ProjetoEscolaAPI.Models;
using ProjetoEscolaAPI.Repositories;
using System;

namespace ProjetoEscolaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly TurmaR _reposTurma;

        public TurmaController(TurmaR reposTurma)
        {
            _reposTurma = reposTurma;
        }

        [HttpPost]
        public ContentResult Post([FromBody] JObject dados)
        {
            var turma = JsonConvert.DeserializeObject<Turma>(dados.ToString());
            turma.DataCriacao = DateTime.Now;

            if (_reposTurma.Registrar(turma))
                return new ContentResult { StatusCode = (int)Biblioteca.StatusCode.Success };

            return new ContentResult { StatusCode = (int)Biblioteca.StatusCode.BadRequest };
        }
    }
}
