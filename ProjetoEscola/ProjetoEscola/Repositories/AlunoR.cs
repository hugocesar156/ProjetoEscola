using Newtonsoft.Json;
using ProjetoEscola.Global;
using ProjetoEscola.Models.Aluno;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEscola.Repositories
{
    public class AlunoR
    {
        public static async Task<bool> Registrar(Aluno aluno)
        {
            try
            {
                var json = JsonConvert.SerializeObject(aluno);
                var data = new StringContent(json, Encoding.UTF8, Biblioteca.MEDIATYPE);

                var response = await new HttpClient()
                    .PostAsync($"{Biblioteca.API_BASE_URL}aluno", data);

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
