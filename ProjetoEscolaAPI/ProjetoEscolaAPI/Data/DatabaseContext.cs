using Microsoft.EntityFrameworkCore;
using ProjetoEscolaAPI.Models;

namespace ProjetoEscolaAPI.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Professor> Professor { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
