using ComunidadeLivros.Application.Models.Livro;

namespace ComunidadeLivros.Application.Services;

public interface ILivroService
{
    Task<IEnumerable<ReadLivroDto>> ConsultarLivros(int skip = 0, int take = 10);
    Task<ReadLivroDto> ConsultarLivroPorId(int id);
    Task CadastarLivro(CreateLivroDto livroDto);
    Task<bool> AtualizarLivro(int id, UpdateLivroDto livroDto);
    Task<bool> DeletarLivro(int id);
}
