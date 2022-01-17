using Microsoft.EntityFrameworkCore;
using ProjetoEscolaAPI.Models;
using ProjetoEscolaAPI.Models.Aluno;

namespace ProjetoEscolaAPI.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Professor> Professor { get; set; }
        public DbSet<Responsavel> Responsavel { get; set; }
        public DbSet<Turma> Turma { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
