using ComunidadeLivrosAPI.Data;
using ComunidadeLivrosAPI.Dtos;
using ComunidadeLivrosAPI.Models;
using Microsoft.AspNetCore.Mvc;

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
        var livro = new Livro(livroDto.Titulo, livroDto.Genero, livroDto.Autor, livroDto.QntPag);
        _context.Livros.Add(livro);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpGet]
    public IEnumerable<ReadLivroDto> ConsultaLivros([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        var consultaLivros = _context.Livros.Skip(skip).Take(take);

        return consultaLivros.Select(livro =>
            new ReadLivroDto
            {
                Autor = livro.Autor,
                Genero = livro.Genero,
                QntPag = livro.QntPag,
                Titulo = livro.Titulo
            }).ToList();
    }

    [HttpGet("{id}")]
    public IActionResult ConsultaLivroPorId(int id)
    {
        var livro = _context.Livros.FirstOrDefault(livro => livro.Id == id);
        if (livro == null) return NotFound();
        var livroDto = new ReadLivroDto
        {
            Autor = livro.Autor,
            Genero = livro.Genero,
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
        livro.AtualizaInfo(livroDto.Titulo, livroDto.Genero, livroDto.Autor, livroDto.QntPag);
        _context.SaveChanges();
        return NoContent();
    }

   
}
