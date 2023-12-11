using ComunidadeLivros.Core.Entities;
using ComunidadeLivrosAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace ComunidadeLivros.DataAccess.Repositories.Impl;

public class ResenhaRepository : BaseRepository<Resenha>, IResenhaRepository
{
    public ResenhaRepository(LivroContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Resenha>> ConsultarResenhas(int skip, int take)
    {
        return await _dbSet
            .Include(x => x.Livro)
                .ThenInclude(x => x.Genero)
            .Include(x => x.Livro.Autor)
            .Skip(skip).Take(take).ToListAsync();
    }
}
