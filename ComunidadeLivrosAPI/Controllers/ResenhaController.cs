using ComunidadeLivrosAPI.Data;
using ComunidadeLivrosAPI.Dtos.Resenha;
using ComunidadeLivrosAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComunidadeLivrosAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ResenhaController : ControllerBase
{
    private LivroContext _context;

    public ResenhaController(LivroContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult AdicionaResenha([FromBody] CreateResenhaDto resenhaDto)
    {
        var resenha = new Resenha(resenhaDto.LivroId, resenhaDto.TextoResenha);
        _context.Add(resenha);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpGet]
    public IEnumerable<ReadResenhaDto> ConsultaResenhas([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        var consultaResenhas = _context.Resenhas.Skip(skip).Take(take);

        return consultaResenhas.Select(resenha =>
            new ReadResenhaDto
            {
                Id = resenha.Id,
                LivroId = resenha.LivroId,
                TextoResenha = resenha.TextoResenha
            }).ToList();
    }
}
