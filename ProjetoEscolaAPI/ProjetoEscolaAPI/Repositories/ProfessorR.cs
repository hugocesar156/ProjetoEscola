using ProjetoEscolaAPI.Models;
using System;

namespace ProjetoEscolaAPI.Repositories
{
    public class ProfessorR
    {
        private readonly Data.DatabaseContext _banco;

        public ProfessorR(Data.DatabaseContext banco) => _banco = banco;

        public bool Registrar(Professor professor)
        {
            try
            {
                _banco.Add(professor);
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
