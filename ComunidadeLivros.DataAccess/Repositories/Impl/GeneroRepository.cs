using ComunidadeLivros.Core.Entities;
using ComunidadeLivrosAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace ComunidadeLivros.DataAccess.Repositories.Impl;

public class GeneroRepository : BaseRepository<Genero>, IGeneroRepository
{
    public GeneroRepository(LivroContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Genero>> ConsultarGeneros(int skip = 0, int take = 10)
    {
        return await _dbSet.Skip(skip).Take(take).ToListAsync();
    }
}
