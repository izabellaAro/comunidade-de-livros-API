using ComunidadeLivros.Core.Entities;

namespace ComunidadeLivros.DataAccess.Repositories;

public interface ILivroRepository : IBaseRepository<Livro>
{
    Task<IEnumerable<Livro>> ConsultarLivros(int skip = 0, int take = 50);
    Task<Livro> ConsultarLivroPorId(int id);
}
