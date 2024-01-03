using ComunidadeLivros.Application.Models.Autor;
using ComunidadeLivros.Application.Models.Genero;
using ComunidadeLivros.Application.Models.Resenha;

namespace ComunidadeLivros.Application.Models.Livro;

public class ReadLivroDto
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public ReadGeneroDto Genero { get; set; }
    public ReadAutorDto Autor { get; set; }
    public IList<ReadResenhaDto> Resenhas { get; set; }
    public int QntPag { get; set; }
}
