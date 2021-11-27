using ProjetoEscolaAPI.Models;
using System;
using System.Linq;

namespace ProjetoEscolaAPI.Repositories
{
    public class UsuarioR
    {
        private readonly Data.DatabaseContext _banco;

        public UsuarioR(Data.DatabaseContext banco) => _banco = banco;

        public Usuario Buscar(string email)
        {
            try
            {
                return _banco.Usuario.FirstOrDefault(u => u.Email == email);
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return null;
            }
        }
    }
}
