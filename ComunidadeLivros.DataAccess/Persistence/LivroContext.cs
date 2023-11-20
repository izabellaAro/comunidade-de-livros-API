using ComunidadeLivros.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ComunidadeLivrosAPI.Data;

public class LivroContext : DbContext
{
    public LivroContext(DbContextOptions<LivroContext>opts) : base(opts)
    {

    }

    public DbSet<Livro> Livros { get; set; }
    public DbSet<Genero> Generos { get; set; }
    public DbSet<Autor> Autores { get; set; }
    public DbSet<Resenha> Resenhas { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
