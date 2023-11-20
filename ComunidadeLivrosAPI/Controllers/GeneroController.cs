using ComunidadeLivros.Application.Models.Genero;
using ComunidadeLivros.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ComunidadeLivrosAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GeneroController : ControllerBase
{
    private readonly IGeneroService _generoService;

    public GeneroController(IGeneroService generoService)
    {
        _generoService = generoService;
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarGenero([FromBody] CreateGeneroDto generoDto)
    {
        await _generoService.CadastrarGenero(generoDto);
        return NoContent();
    }

    [HttpGet]
    public async Task<IEnumerable<ReadGeneroDto>> ConsultaGeneros([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return await _generoService.ConsultarGeneros(skip, take);
    }
}
