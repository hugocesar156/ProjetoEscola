using ProjetoEscola.Global;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEscola.Models.Aluno
{
    public class Endereco
    {
        private string _cep;
        private string _logradouro;
        private string _bairro;
        private string _numero;
        private string _cidade;
        private string _complemento;

        public uint IdEndereco { get; set; }

        [Required(ErrorMessage = Biblioteca.CAMPO_OBRIGATORIO)]
        public string Cep 
        { 
            get => _cep; 
            set => _cep = value?.Replace("-", ""); 
        }

        [Required(ErrorMessage = Biblioteca.CAMPO_OBRIGATORIO)]
        public string Logradouro
        {
            get => _logradouro;
            set => _logradouro = value?.Trim().ToUpper();
        }

        [Required(ErrorMessage = Biblioteca.CAMPO_OBRIGATORIO)]
        public string Bairro
        {
            get => _bairro;
            set => _bairro = value?.Trim().ToUpper();
        }

        [Required(ErrorMessage = Biblioteca.CAMPO_OBRIGATORIO)]
        public string Numero
        {
            get => _numero;
            set => _numero = value?.Trim().ToUpper();
        }

        [Required(ErrorMessage = Biblioteca.CAMPO_OBRIGATORIO)]
        public string Cidade
        {
            get => _cidade;
            set => _cidade = value?.Trim().ToUpper();
        }

        [Required(ErrorMessage = Biblioteca.CAMPO_OBRIGATORIO), 
        StringLength(2, ErrorMessage = Biblioteca.CAMPO_INVALIDO)]
        public string Uf { get; set; }

        public string Complemento
        {
            get => _complemento;
            set => _complemento = value?.Trim().ToUpper();
        }

        public static Dictionary<string, string> ListarEstados()
        {
            return new Dictionary<string, string>
            {
                {"AC", "Acre"},
                {"AL", "Alagoas"},
                {"AP", "Amapá"},
                {"AM", "Amazonas"},
                {"BA", "Bahia"},
                {"CE", "Ceará"},
                {"DF", "Distrito Federal"},
                {"ES", "Esperito Santo"},
                {"GO", "Goiás"},
                {"MA", "Maranhão"},
                {"MT", "Manto Grosso"},
                {"MS", "Mato Grosso do Sul"},
                {"MG", "Minas Gerais"},
                {"PA", "Pará"},
                {"PB", "Paraíba"},
                {"PR", "Paraná"},
                {"PE", "Pernambuco"},
                {"PI", "Piauí"},
                {"RJ", "Rio de Janeiro"},
                {"RN", "Rio Grande do Norte"},
                {"RS", "Rio Grande do Sul"},
                {"RO", "Rondônia"},
                {"RR", "Roraima"},
                {"SC", "Santa Catarina"},
                {"SP", "São Paulo"},
                {"SE", "Sergipe"},
                {"TO", "Tocantins"},
            };
        }
    }
}
