using Newtonsoft.Json;
using ProjetoEscola.Global;
using ProjetoEscola.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEscola.Repositories
{
    public class ProfessorR
    {
        public static async Task<bool> Registrar(Professor professor)
        {
            try
            {
                var json = JsonConvert.SerializeObject(professor);
                var data = new StringContent(json, Encoding.UTF8, Biblioteca.MEDIATYPE);

                var response = await new HttpClient()
                    .PostAsync($"{Biblioteca.API_BASE_URL}professor", data);

                return response.IsSuccessStatusCode;
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return false;
            }
        }
    }
}
