using ComunidadeLivros.Application.Models.Genero;

namespace ComunidadeLivros.Application.Models.Autor;

public class ReadAutorDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public ReadGeneroDto Genero { get; set; }
}
