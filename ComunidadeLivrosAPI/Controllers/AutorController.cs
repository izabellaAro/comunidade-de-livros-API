using ComunidadeLivrosAPI.Data;
using ComunidadeLivrosAPI.Dtos.Autor;
using ComunidadeLivrosAPI.Dtos.Genero;
using ComunidadeLivrosAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ComunidadeLivrosAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AutorController : ControllerBase
{
    private LivroContext _context;

    public AutorController(LivroContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult AdicionarAutor([FromBody] CreateAutorDto autorDto)
    {
        var autor = new Autor (autorDto.Nome);
        _context.Add(autor);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpGet]
    public IEnumerable<ReadAutorDto> ConsultaAutores([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        var consultaAutores = _context.Autores.Skip(skip).Take(take);

        return consultaAutores.Select(autor =>
            new ReadAutorDto
            {
                Id = autor.Id,
                Nome = autor.Nome
            }).ToList();
    }
}
