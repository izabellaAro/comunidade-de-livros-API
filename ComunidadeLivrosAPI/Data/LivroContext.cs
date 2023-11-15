using ComunidadeLivrosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ComunidadeLivrosAPI.Data;

public class LivroContext : DbContext
{
    public LivroContext(DbContextOptions<LivroContext>opts) : base(opts)
    {

    }

    public DbSet<Livro> Livros { get; set; }
    public DbSet<Genero> Generos { get; set; }
}
