using ComunidadeLivros.Application.Models.Autor;
using ComunidadeLivros.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ComunidadeLivrosAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AutorController : ControllerBase
{
    private readonly IAutorService _autorService;
    public AutorController(IAutorService autorService)
    {
        _autorService = autorService;
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarAutor([FromBody] CreateAutorDto autorDto)
    {
        await _autorService.CadastrarAutor(autorDto);
        return NoContent();
    }

    [HttpGet]
    public async Task<IEnumerable<ReadAutorDto>> ConsultaAutores([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return await _autorService.ConsultarAutores(skip, take);
    }
}
