using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjetoEscolaAPI.Models;
using ProjetoEscolaAPI.Repositories;
using System;

namespace ProjetoEscolaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly ProfessorR _reposProfessor;

        public ProfessorController(ProfessorR reposProfessor)
        {
            _reposProfessor = reposProfessor;
        }

        [HttpPost]
        public ContentResult Post([FromBody] JObject dados)
        {
            var professor = JsonConvert.DeserializeObject<Professor>(dados.ToString());
            professor.DataCriacao = DateTime.Now;

            var criptografia = Usuario.GerarCriptografia("123456");
            professor.Usuario.Senha = criptografia.Item1;
            professor.Usuario.Hash = criptografia.Item2;
            professor.Usuario.DataCriacao = DateTime.Now;

            if (_reposProfessor.Registrar(professor))
                return new ContentResult { StatusCode = 200 };

            return new ContentResult { StatusCode = 400 };
        }
    }
}
