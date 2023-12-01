using ComunidadeLivros.Core.Entities;

namespace ComunidadeLivros.Application.Models.Autor;

public class CreateAutorDto
{
    public string Nome { get; set; }
    public  int GeneroId { get; set; }
}
