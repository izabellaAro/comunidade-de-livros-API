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
        return Ok();
    }

}
