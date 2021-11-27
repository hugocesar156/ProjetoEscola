using ProjetoEscola.Global;
using ProjetoEscola.Validations;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEscola.Models
{
    public class Professor
    {
        private string _nome;
        private string _cpf;

        public uint Id { get; set; }

        [Required(ErrorMessage = Biblioteca.CAMPO_OBRIGATORIO), 
        MaxLength(50, ErrorMessage = Biblioteca.CAMPO_INVALIDO)]
        public string Nome 
        {
            get => _nome; 
            set => _nome = value?.Trim().ToUpper(); 
        }

        [Required(ErrorMessage = Biblioteca.CAMPO_OBRIGATORIO), Cpf]
        public string Cpf 
        {
            get => _cpf; 
            set => _cpf = value?.Replace(".", "").Replace("-", ""); 
        }

        public Usuario Usuario { get; set; }
    }
}
