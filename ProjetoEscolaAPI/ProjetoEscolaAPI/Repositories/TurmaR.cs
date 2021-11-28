using ProjetoEscolaAPI.Models;
using System;

namespace ProjetoEscolaAPI.Repositories
{
    public class TurmaR
    {
        private readonly Data.DatabaseContext _banco;
        public TurmaR(Data.DatabaseContext banco) => _banco = banco;

        public bool Registrar(Turma turma)
        {
            try
            {
                _banco.Add(turma);
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
