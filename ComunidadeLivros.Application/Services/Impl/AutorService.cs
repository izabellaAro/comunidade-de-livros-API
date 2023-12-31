﻿using ComunidadeLivros.Application.Models.Autor;
using ComunidadeLivros.Application.Models.Genero;
using ComunidadeLivros.Core.Entities;
using ComunidadeLivros.DataAccess.Repositories;

namespace ComunidadeLivros.Application.Services.Impl;

public class AutorService : IAutorService
{
    private readonly IAutorRepository _autorRepository;

    public AutorService(IAutorRepository autorRepository)
    {
        _autorRepository = autorRepository;
    }

    public async Task CadastrarAutor(CreateAutorDto autorDto)
    {
        var autor = new Autor(autorDto.Nome, autorDto.GeneroId);
        await _autorRepository.AddAsync(autor);
    }

    public async Task<IEnumerable<ReadAutorDto>> ConsultarAutores(int skip = 0, int take = 15)
    {
        var autores = await  _autorRepository.ConsultarAutores(skip, take);

        return autores.Select(autor =>
        new ReadAutorDto
         {
             Id = autor.Id,
             Nome = autor.Nome,
             Genero = new ReadGeneroDto 
             { 
                 Id = autor.GeneroAutor.Id, 
                 Nome = autor.GeneroAutor.Nome 
             }
         }).ToList();

    }
}
