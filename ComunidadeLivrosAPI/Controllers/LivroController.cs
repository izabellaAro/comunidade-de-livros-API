using ComunidadeLivrosAPI.Data;
using ComunidadeLivrosAPI.Dtos;
using ComunidadeLivrosAPI.Dtos.Autor;
using ComunidadeLivrosAPI.Dtos.Genero;
using ComunidadeLivrosAPI.Dtos.Livro;
using ComunidadeLivrosAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComunidadeLivrosAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class LivroController : Controller
{
    private LivroContext _context;

    public LivroController(LivroContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult AdicionarLivro([FromBody] CreateLivroDto livroDto)
    {
        var livro = new Livro(livroDto.Titulo, livroDto.GeneroId, livroDto.AutorId, livroDto.QntPag);
        _context.Livros.Add(livro);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpGet]
    public IEnumerable<ReadLivroDto> ConsultaLivros([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        var consultaLivros = _context.Livros
            .Include(livro => livro.Genero)
            .Include(livro => livro.Autor)
            .Skip(skip).Take(take);

        return consultaLivros.Select(livro =>
            new ReadLivroDto
            {
                Autor = new ReadAutorDto { Id = livro.Autor.Id, Nome = livro.Autor.Nome },
                Genero = new ReadGeneroDto { Id = livro.Genero.Id, Nome = livro.Genero.Nome },
                QntPag = livro.QntPag,
                Titulo = livro.Titulo
            }).ToList();
    }

    [HttpGet("{id}")]
    public IActionResult ConsultaLivroPorId(int id)
    {
        var livro = _context.Livros
            .Include(livro => livro.Genero)
            .Include(livro => livro.Autor)
            .FirstOrDefault(livro => livro.Id == id);
        
        if (livro == null) return NotFound();
        var livroDto = new ReadLivroDto
        {
            Autor = new ReadAutorDto { Id = livro.Autor.Id, Nome = livro.Autor.Nome },
            Genero = new ReadGeneroDto { Id = livro.Genero.Id, Nome = livro.Genero.Nome },
            QntPag = livro.QntPag,
            Titulo = livro.Titulo
        };
        return Ok(livroDto);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaLivro(int id, [FromBody] UpdateLivroDto livroDto)
    {
        var livro = _context.Livros.FirstOrDefault(livro => livro.Id == id);
        if (livro == null) return NotFound();
        livro.AtualizaInfo(livroDto.Titulo, livroDto.GeneroId, livroDto.AutorId, livroDto.QntPag);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaFilme(int id)
    {
        var livro = _context.Livros.FirstOrDefault(livro => livro.Id == id);
        if (livro == null) return NotFound();
        _context.Remove(livro);
        _context.SaveChanges();
        return NoContent();
    }
}
