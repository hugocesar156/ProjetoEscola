using ProjetoEscola.Global;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEscola.Models
{
    public class Usuario
    {
        public uint Id { get; set; }

        [Required(ErrorMessage = Biblioteca.CAMPO_OBRIGATORIO), 
        MaxLength(60, ErrorMessage = Biblioteca.CAMPO_INVALIDO), 
        EmailAddress(ErrorMessage = Biblioteca.EMAIL_INVALIDO)]
        public string Email { get; set; }

        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = Biblioteca.SENHA_INCORRETA)]
        public string ConfirmaSenha { get; set; }
    }
}
