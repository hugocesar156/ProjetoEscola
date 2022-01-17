using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjetoEscolaAPI.Global;
using ProjetoEscolaAPI.Models;
using ProjetoEscolaAPI.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ProjetoEscolaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UsuarioR _reposUsuario;

        public UsuarioController(IConfiguration configuration, UsuarioR reposUsuario)
        {
            _configuration = configuration;
            _reposUsuario = reposUsuario;
        }

        [HttpPost("login")]
        public ContentResult Login([FromBody] JObject dados)
        {
            var usuario = _reposUsuario.Buscar(dados["email"].ToString());

            if (usuario == null || !Usuario.ValidarCriptografia(dados["senha"].ToString(), usuario.Senha))
                return new ContentResult { StatusCode = (int)Biblioteca.StatusCode.BadRequest };

            return new ContentResult
            {
                Content = GerarToken(usuario),
                ContentType = Biblioteca.MEDIATYPE,
                StatusCode = (byte)Biblioteca.StatusCode.Success
            };
        }

        [HttpGet("{email}"), Authorize]
        public ContentResult Get(string email)
        {
            var usuario = _reposUsuario.Buscar(email);

            return new ContentResult
            {
                Content = JsonConvert.SerializeObject(usuario),
                ContentType = Biblioteca.MEDIATYPE,
                StatusCode = (int)Biblioteca.StatusCode.Success
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

        private string GerarToken(Usuario usuario)
        {
            var claims = new List<Claim>
            {
                new Claim("ID", usuario.Id.ToString()),
                new Claim(ClaimTypes.Email, usuario.Email),
            };

            var chave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credenciais);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
