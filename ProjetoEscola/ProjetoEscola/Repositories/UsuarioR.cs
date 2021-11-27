using Newtonsoft.Json;
using ProjetoEscola.Global;
using ProjetoEscola.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEscola.Repositories
{
    public class UsuarioR
    {
        public static async Task<Usuario> Buscar(string email)
        {
            try
            {
                var response = await new HttpClient()
                    .GetAsync($"{Biblioteca.API_BASE_URL}usuario/{email}");

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
    }
}
