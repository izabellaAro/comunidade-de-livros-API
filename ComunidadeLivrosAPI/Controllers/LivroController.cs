using ComunidadeLivros.Application.Models.Livro;
using ComunidadeLivros.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ComunidadeLivrosAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class LivroController : Controller
{
    private readonly ILivroService _livroService;

    public LivroController(ILivroService livroService)
    {
        _livroService = livroService;
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarLivro([FromBody] CreateLivroDto livroDto)
    {
        await _livroService.CadastarLivro(livroDto);
        return NoContent();
    }

    [HttpGet]
    public async Task<IEnumerable<ReadLivroDto>> ConsultaLivros([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return await _livroService.ConsultarLivros(skip, take);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ConsultaLivroPorId(int id)
    {
        var livro = await _livroService.ConsultarLivroPorId(id);

        if (livro == null) return NotFound();

        return Ok(livro);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizaLivro(int id, [FromBody] UpdateLivroDto livroDto)
    {
        var livroAtualizado = await _livroService.AtualizarLivro(id, livroDto);
        if (livroAtualizado == false) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletaLivro(int id)
    {
        var livro = await _livroService.DeletarLivro(id);
        if (livro == false) return NotFound();
        return NoContent();
    }
}
