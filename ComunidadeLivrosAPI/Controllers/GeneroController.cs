using ComunidadeLivrosAPI.Data;
using ComunidadeLivrosAPI.Dtos;
using ComunidadeLivrosAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComunidadeLivrosAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GeneroController : ControllerBase
{
    private LivroContext _context;

    public GeneroController(LivroContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult AdicionarGenero([FromBody] CreateGeneroDto generoDto)
    {
        var genero = new Genero(generoDto.Nome);
        _context.Add(genero);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpGet]
    public IEnumerable<ReadGeneroDto> ConsultaGeneros([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        var consultaGenero = _context.Generos.Skip(skip).Take(take);

        return consultaGenero.Select(genero =>
            new ReadGeneroDto
            {
                Id = genero.Id,
                Nome = genero.Nome
            }).ToList();
    }
}
