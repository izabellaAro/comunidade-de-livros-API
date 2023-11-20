using ComunidadeLivros.Application.Models.Resenha;

namespace ComunidadeLivros.Application.Services;

public interface IResenhaService
{
    Task<IEnumerable<ReadResenhaDto>> ConsultarResenhas(int skip = 0, int take = 10);
    Task CadastrarResenha(CreateResenhaDto resenhaDto);
}
