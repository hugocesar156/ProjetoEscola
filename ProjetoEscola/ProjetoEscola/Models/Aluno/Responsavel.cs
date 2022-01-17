using System.Collections.Generic;

namespace ProjetoEscola.Models.Aluno
{
    public class Responsavel
    {
        public uint Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public List<Aluno> Aluno { get; set; }
    }
}
