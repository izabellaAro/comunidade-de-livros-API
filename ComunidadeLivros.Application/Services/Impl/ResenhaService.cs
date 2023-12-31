﻿using ComunidadeLivros.Application.Models.Resenha;
using ComunidadeLivros.Core.Entities;
using ComunidadeLivros.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ComunidadeLivros.Application.Services.Impl;

public class ResenhaService : IResenhaService
{
    private readonly IResenhaRepository _resenhaRepository;

    public ResenhaService(IResenhaRepository resenhaRepository)
    {
        _resenhaRepository = resenhaRepository;
    }
    public async Task CadastrarResenha(CreateResenhaDto resenhaDto)
    {
        var resenha = new Resenha(resenhaDto.LivroId, resenhaDto.TextoResenha, resenhaDto.TituloResenha);
        await _resenhaRepository.AddAsync(resenha);
    }

    public async Task<IEnumerable<ReadResenhaDto>> ConsultarResenhas(int skip = 0, int take = 10)
    {
        var consultaResenhas = await _resenhaRepository.ConsultarResenhas(skip, take);

        return consultaResenhas.Select(resenha =>
            new ReadResenhaDto
            {
                Id = resenha.Id,
                TituloResenha = resenha.TituloResenha,
                TextoResenha = resenha.TextoResenha,
                LivroId = resenha.LivroId,
                TituloLivro = resenha.Livro.Titulo,
                NomeGenero = resenha.Livro.Genero.Nome,
                NomeAutor = resenha.Livro.Autor.Nome
            }).ToList();
    }
}
