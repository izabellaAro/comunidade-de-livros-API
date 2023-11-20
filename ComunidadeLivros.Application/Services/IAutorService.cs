using ComunidadeLivros.Application.Models.Autor;

namespace ComunidadeLivros.Application.Services;

public interface IAutorService
{
    Task<IEnumerable<ReadAutorDto>> ConsultarAutores(int skip = 0, int take = 10);
    Task CadastrarAutor(CreateAutorDto autorDto);
}
