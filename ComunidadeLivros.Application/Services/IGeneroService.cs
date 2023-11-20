using ComunidadeLivros.Application.Models.Genero;

namespace ComunidadeLivros.Application.Services;

public interface IGeneroService
{
    Task<IEnumerable<ReadGeneroDto>> ConsultarGeneros(int skip = 0, int take = 10);
    Task CadastrarGenero(CreateGeneroDto generoDto);
}
