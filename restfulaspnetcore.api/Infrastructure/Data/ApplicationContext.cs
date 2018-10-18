using Microsoft.EntityFrameworkCore;
using restfulaspnetcore.api.Model;

namespace restfulaspnetcore.api.Infrastructure.Data
{
    public class ContextoAplicacao : DbContext
    {
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Livro> Livros { get; set; }

        public ContextoAplicacao(DbContextOptions options): base(options) {
            this.Database.EnsureCreated();
        }
    }
}