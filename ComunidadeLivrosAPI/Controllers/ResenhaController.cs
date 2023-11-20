using ComunidadeLivros.Application.Models.Resenha;
using ComunidadeLivros.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ComunidadeLivrosAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ResenhaController : ControllerBase
{
    private readonly IResenhaService _resenhaService;

    public ResenhaController(IResenhaService resenhaService)
    {
        _resenhaService = resenhaService;
    }

    [HttpPost]
    public async Task<IActionResult> AdicionaResenha([FromBody] CreateResenhaDto resenhaDto)
    {
        await _resenhaService.CadastrarResenha(resenhaDto);
        return NoContent();
    }

    [HttpGet]
    public async Task<IEnumerable<ReadResenhaDto>> ConsultaResenhas([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return await _resenhaService.ConsultarResenhas(skip, take);
    }
}
