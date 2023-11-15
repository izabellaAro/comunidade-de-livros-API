using ComunidadeLivrosAPI.Dtos.Autor;
using ComunidadeLivrosAPI.Dtos.Genero;

namespace ComunidadeLivrosAPI.Dtos.Livro;

public class ReadLivroDto
{
    public string Titulo { get; set; }
    public ReadGeneroDto Genero { get; set; }
    public ReadAutorDto Autor { get; set; }
    public int QntPag { get; set; }
}
