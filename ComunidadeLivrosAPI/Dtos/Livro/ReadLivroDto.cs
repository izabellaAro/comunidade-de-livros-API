using ComunidadeLivrosAPI.Dtos.Autor;
using ComunidadeLivrosAPI.Dtos.Genero;
using ComunidadeLivrosAPI.Dtos.Resenha;

namespace ComunidadeLivrosAPI.Dtos.Livro;

public class ReadLivroDto
{
    public string Titulo { get; set; }
    public ReadGeneroDto Genero { get; set; }
    public ReadAutorDto Autor { get; set; }
    public IList<ReadResenhaDto> Resenhas { get; set; }
    public int QntPag { get; set; }
}
