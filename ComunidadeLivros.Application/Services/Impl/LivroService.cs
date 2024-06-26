﻿using ComunidadeLivros.Application.Models.Autor;
using ComunidadeLivros.Application.Models.Genero;
using ComunidadeLivros.Application.Models.Livro;
using ComunidadeLivros.Application.Models.Resenha;
using ComunidadeLivros.Core.Entities;
using ComunidadeLivros.DataAccess.Repositories;
using Microsoft.AspNetCore.Http;

namespace ComunidadeLivros.Application.Services.Impl;

public class LivroService : ILivroService
{
    private readonly ILivroRepository _livroRepository;
    private readonly IAmazonS3Service _amazonS3Service;

    public LivroService(ILivroRepository livroRepository, IAmazonS3Service amazonS3Service)
    {
        _livroRepository = livroRepository;
        _amazonS3Service = amazonS3Service;
    }

    public async Task<bool> AtualizarLivro(int id,UpdateLivroDto livroDto)
    {
        var livro = await _livroRepository.ConsultarLivroPorId(id);
        if (livro == null) return false;
        livro.AtualizaInfo(livroDto.Titulo, livroDto.GeneroId, livroDto.AutorId, livroDto.QntPag);
        await _livroRepository.UpdateAsync(livro);
        return true;
    }

    public async Task CadastarLivro(CreateLivroDto livroDto)
    {
        var livro = new Livro(livroDto.Titulo, livroDto.GeneroId, livroDto.AutorId, livroDto.QntPag);
        await _livroRepository.AddAsync(livro);
    }

    public async Task<ReadLivroDto> ConsultarLivroPorId(int id)
    {
        var livro = await _livroRepository.ConsultarLivroPorId(id);

        if (livro == null) return null;

        return new ReadLivroDto
        {
            Autor = new ReadAutorDto { Id = livro.Autor.Id, Nome = livro.Autor.Nome },
            Genero = new ReadGeneroDto { Id = livro.Genero.Id, Nome = livro.Genero.Nome },
            Resenhas = livro.Resenhas
                    .Select(resenha => new ReadResenhaDto
                    {
                        Id = resenha.Id,
                        LivroId = resenha.LivroId,
                        TextoResenha = resenha.TextoResenha
                    }).ToList(),
            QntPag = livro.QntPag,
            Titulo = livro.Titulo
        };
    }

    public async Task<IEnumerable<ReadLivroDto>> ConsultarLivros(int skip = 0, int take = 10)
    {
        var consultaLivros = await _livroRepository.ConsultarLivros(skip, take);
            
        return consultaLivros.Select(livro =>
            new ReadLivroDto
            {
                Id = livro.Id,
                Autor = new ReadAutorDto { Id = livro.Autor.Id, Nome = livro.Autor.Nome },
                Genero = new ReadGeneroDto { Id = livro.Genero.Id, Nome = livro.Genero.Nome },
                Resenhas = livro.Resenhas
                    .Select(resenha => new ReadResenhaDto
                    {
                        Id = resenha.Id,
                        LivroId = resenha.LivroId,
                        TextoResenha = resenha.TextoResenha
                    }).ToList(),
                QntPag = livro.QntPag,
                Titulo = livro.Titulo
            }).ToList();
    }

    public async Task<bool> DeletarLivro(int id)
    {
        var livro = await _livroRepository.ConsultarLivroPorId(id);
        if (livro == null) return false;
        await _livroRepository.DeleteAsync(livro);
        return true;
    }

    public async Task<bool> AdicionarImg(AddArquivoLivroDto arquivoDto)
    {
        var livro = await _livroRepository.ConsultarLivroPorId(arquivoDto.LivroId);

        if (livro == null)
        {
            return false;
        }

        var key = "medias/" + Guid.NewGuid();
        var arquivoEnviado = await _amazonS3Service.EnviarArquivo("imagenslivro", key, arquivoDto.Arquivo);

        if (!arquivoEnviado)
        {
            return false;
        }

        livro.AdicionarChaveImg(key);
        await _livroRepository.UpdateAsync(livro);

        return true;
    }
}
