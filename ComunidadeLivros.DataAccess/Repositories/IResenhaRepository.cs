using ComunidadeLivros.Core.Entities;

namespace ComunidadeLivros.DataAccess.Repositories;

public interface IResenhaRepository : IBaseRepository<Resenha>
{
    Task<IEnumerable<Resenha>> ConsultarResenhas(int skip, int take);
}
