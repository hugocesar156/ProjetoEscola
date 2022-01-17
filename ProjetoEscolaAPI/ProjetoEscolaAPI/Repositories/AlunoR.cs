using ProjetoEscolaAPI.Models.Aluno;
using System;

namespace ProjetoEscolaAPI.Repositories
{
    public class AlunoR
    {
        private readonly Data.DatabaseContext _banco;

        public AlunoR(Data.DatabaseContext banco) => _banco = banco;

        public bool Registrar(Aluno aluno)
        {
            try
            {
                _banco.Add(aluno);
                return _banco.SaveChanges() > 0;
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return false;
            }
        }
    }
}
