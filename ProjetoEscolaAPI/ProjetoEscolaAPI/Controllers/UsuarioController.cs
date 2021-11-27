using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjetoEscolaAPI.Models;
using ProjetoEscolaAPI.Repositories;

namespace ProjetoEscolaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioR _reposUsuario;

        public UsuarioController(UsuarioR reposUsuario)
        {
            _reposUsuario = reposUsuario;
        }

        [HttpPost("login")]
        public ContentResult Login([FromBody] JObject dados)
        {
            var usuario = _reposUsuario.Buscar(dados["email"].ToString());

            if (usuario == null || !Usuario.ValidarCriptografia(dados["senha"].ToString(), usuario.Senha))
                return new ContentResult { StatusCode = 400 };

            return new ContentResult
            {
                Content = JsonConvert.SerializeObject(usuario),
                ContentType = "application/json",
                StatusCode = 200
            };
        }

        [HttpGet("{email}")]
        public ContentResult Get(string email)
        {
            var usuario = _reposUsuario.Buscar(email);

            return new ContentResult
            {
                Content = JsonConvert.SerializeObject(usuario),
                ContentType = "application/json",
                StatusCode = 200
            };
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
