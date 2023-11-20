using ComunidadeLivros.Core.Entities;

namespace ComunidadeLivros.DataAccess.Repositories;

public interface IGeneroRepository : IBaseRepository<Genero>
{
    Task<IEnumerable<Genero>> ConsultarGeneros(int skip = 0, int take = 10);
}
