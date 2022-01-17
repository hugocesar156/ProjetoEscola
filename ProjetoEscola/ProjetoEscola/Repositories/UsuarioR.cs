using Newtonsoft.Json;
using ProjetoEscola.Global;
using ProjetoEscola.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ProjetoEscola.Token;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace ProjetoEscola.Repositories
{
    public class UsuarioR
    {
        public static async Task<Usuario> Buscar(string email)
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Tokens.Usuario[2]);

                var response = await client.GetAsync($"{Biblioteca.API_BASE_URL}usuario/{email}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Usuario>(content);
                }

                return null;
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return null;
            }
        }

        public static async Task<Usuario> ValidarAcesso(string email, string senha)
        {
            try
            {
                var json = JsonConvert.SerializeObject(new { email, senha });
                var data = new StringContent(json, Encoding.UTF8, Biblioteca.MEDIATYPE);

                var response = await new HttpClient()
                    .PostAsync($"{Biblioteca.API_BASE_URL}usuario/login", data);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var handler = new JwtSecurityTokenHandler();
                    var token = handler.ReadJwtToken(content);

                    var idUsuario = uint.Parse(token.Claims.FirstOrDefault(c => c.Type == "ID").Value);

                    if (Tokens.Usuario.ContainsKey(idUsuario))
                        Tokens.Usuario.Remove(idUsuario);

                    Tokens.Usuario.Add(idUsuario, content);

                    return new Usuario
                    {
                        Id = idUsuario,
                        Email = token.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value
                    };
                }

                return null;
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return null;
            }
        }
    }
}
