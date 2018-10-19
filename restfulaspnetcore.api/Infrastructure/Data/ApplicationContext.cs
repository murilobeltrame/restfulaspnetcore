using System;
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

        // protected override void OnModelCreating(ModelBuilder modelBuilder) {
            
        //     var _author01 = Guid.NewGuid();
        //     var _author02 = Guid.NewGuid();
        //     var _author03 = Guid.NewGuid();
        //     var _author04 = Guid.NewGuid();
        //     var _author05 = Guid.NewGuid();
        //     var _author06 = Guid.NewGuid();
        //     var _author07 = Guid.NewGuid();
        //     var _author08 = Guid.NewGuid();
        //     var _author09 = Guid.NewGuid();
        //     var _author10 = Guid.NewGuid();
        //     var _author11 = Guid.NewGuid();
        //     var _author12 = Guid.NewGuid();
        //     var _author13 = Guid.NewGuid();
        //     var _author14 = Guid.NewGuid();
        //     var _author15 = Guid.NewGuid();

        //     modelBuilder.Entity<Autor>().HasData(
        //         new Autor{Id = _author01, Nome = "Nir", Sobrenome = "Eyal"},
        //         new Autor{Id = _author02, Nome="Alec", Sobrenome="Ross"},
        //         new Autor{Id = _author03, Nome="Kevin", Sobrenome="Kelly"},
        //         new Autor{Id = _author04, Nome="Ashlee", Sobrenome="Vance"},
        //         new Autor{Id = _author05, Nome="Brad", Sobrenome="Stone"},
        //         new Autor{Id = _author06, Nome="Deckle", Sobrenome="Edge"},
        //         new Autor{Id = _author07, Nome="Ben", Sobrenome="Horowitz"},
        //         new Autor{Id = _author08, Nome="Peter", Sobrenome="Diamandis"},
        //         new Autor{Id = _author09, Nome="Peter", Sobrenome="Thiel"},
        //         new Autor{Id = _author10, Nome="Eric", Sobrenome="Schmidt"},
        //         new Autor{Id = _author11, Nome="Antonio", Sobrenome="Garcia Martinez"},
        //         new Autor{Id = _author12, Nome="Adam", Sobrenome="Grant"},
        //         new Autor{Id = _author13, Nome="Colestous", Sobrenome="Juma"},
        //         new Autor{Id = _author14, Nome="Ducan", Sobrenome="Clark"},
        //         new Autor{Id = _author15, Nome="Donald", Sobrenome="Knuth"}
        //     );
        //     modelBuilder.Entity<Livro>().HasData(
        //         new {Id = Guid.NewGuid(), Titulo = "Hooked: How to Build Habit-Forming Products", Paginas = 256, AutorId = _author01},
        //         new {Id = Guid.NewGuid(), Titulo = "The Industries of the Future", Paginas = 320, AutorId = _author02},
        //         new {Id = Guid.NewGuid(), Titulo = "The Inevitable: Understanding the 12 Technological Forces That Will Shape Our Future", Paginas = 336, AutorId = _author03},
        //         new {Id = Guid.NewGuid(), Titulo = "Elon Musk: Tesla, SpaceX, and the Quest for a Fantastic Future", Paginas = 416, AutorId = _author04},
        //         new {Id = Guid.NewGuid(), Titulo = "The Upstarts: How Uber, Airbnb, and the Killer Companies of the New Silicon Valley Are Changing the World", Paginas = 384, AutorId = _author05},
        //         new {Id = Guid.NewGuid(), Titulo = "Lean In: Women, Work, and the Will to Lead", Paginas = 240, AutorId = _author06},
        //         new {Id = Guid.NewGuid(), Titulo = "The Hard Thing About Hard Things: Building a Business When There Are No Easy Answers", Paginas = 304, AutorId = _author07},
        //         new {Id = Guid.NewGuid(), Titulo = "Bold: How to Go Big, Create Wealth and Impact the World", Paginas = 336, AutorId = _author08},
        //         new {Id = Guid.NewGuid(), Titulo = "Zero to One", Paginas = 224, AutorId = _author09},
        //         new {Id = Guid.NewGuid(), Titulo = "How Google Works", Paginas = 304, AutorId = _author10},
        //         new {Id = Guid.NewGuid(), Titulo = "Chaos Monkeys: Obscene Fortune and Random Failure in Silicon Valley", Paginas = 528, AutorId = _author11},
        //         new {Id = Guid.NewGuid(), Titulo = "Originals: How Non-Conformists Move the World", Paginas = 336, AutorId = _author12},
        //         new {Id = Guid.NewGuid(), Titulo = "Innovation and Its Enemies: Why People Resist New Technologies", Paginas = 432, AutorId = _author13},
        //         new {Id = Guid.NewGuid(), Titulo = "Alibaba: The House That Jack Ma Built", Paginas = 304, AutorId = _author14},
        //         new {Id = Guid.NewGuid(), Titulo = "The Art of Computer Programming", Paginas = 3168, AutorId = _author15},
        //         new {Id = Guid.NewGuid(), Titulo = "Concrete Mathematics: A Foundation for Computer Science", Paginas = 672, AutorId = _author15},
        //         new {Id = Guid.NewGuid(), Titulo = "What Technology Wants", Paginas = 413, AutorId = _author03},
        //         new {Id = Guid.NewGuid(), Titulo = "New Rules for the New Economy: 10 Radical Strategies for a Connected World", Paginas = 196, AutorId = _author03}
        //     );
        // }
    }
}