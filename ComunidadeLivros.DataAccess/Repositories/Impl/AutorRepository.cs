using ComunidadeLivros.Core.Entities;
using ComunidadeLivrosAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace ComunidadeLivros.DataAccess.Repositories.Impl;

public class AutorRepository : BaseRepository<Autor>, IAutorRepository
{
    public AutorRepository(LivroContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Autor>> ConsultarAutores(int skip, int take)
    {
        return await _dbSet.Skip(skip).Take(take).ToListAsync();
    }
}
