using ComunidadeLivros.Core.Entities;
using ComunidadeLivrosAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace ComunidadeLivros.DataAccess.Repositories.Impl;

public class LivroRepository : BaseRepository<Livro>, ILivroRepository
{
    public LivroRepository(LivroContext context) : base(context)
    {
    }

    public async Task<Livro> ConsultarLivroPorId(int id)
    {
       return await _dbSet
            .Include(livro => livro.Genero)
            .Include(livro => livro.Autor)
            .Include(livro => livro.Resenhas)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Livro>> ConsultarLivros(int skip = 0, int take = 50)
    {
        return await _dbSet
            .Include(livro => livro.Genero)
            .Include(livro => livro.Autor)
            .Include(livro => livro.Resenhas)
            .Skip(skip).Take(take).ToListAsync();
    }
}
