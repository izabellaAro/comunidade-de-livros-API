using ComunidadeLivros.Application.Models.Genero;
using ComunidadeLivros.Core.Entities;
using ComunidadeLivros.DataAccess.Repositories;

namespace ComunidadeLivros.Application.Services.Impl;

public class GeneroService : IGeneroService
{
    private readonly IGeneroRepository _generoRepository;

    public GeneroService(IGeneroRepository generoRepository)
    {
        _generoRepository = generoRepository;
    }

    public async Task CadastrarGenero(CreateGeneroDto generoDto)
    {
        var genero = new Genero(generoDto.Nome);
        await _generoRepository.AddAsync(genero);
    }

    public async Task<IEnumerable<ReadGeneroDto>> ConsultarGeneros(int skip = 0, int take = 10)
    {
        var consultaGenero = await _generoRepository.ConsultarGeneros(skip, take);
        return consultaGenero.Select(genero =>
                    new ReadGeneroDto
                    {
                        Id = genero.Id,
                        Nome = genero.Nome
                    }).ToList();
    }
}
