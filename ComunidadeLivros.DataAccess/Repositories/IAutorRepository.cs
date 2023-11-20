using ComunidadeLivros.Core.Entities;

namespace ComunidadeLivros.DataAccess.Repositories;

public interface IAutorRepository : IBaseRepository<Autor>
{
    Task<IEnumerable<Autor>> ConsultarAutores(int skip, int take);
}
