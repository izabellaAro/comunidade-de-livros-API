namespace ComunidadeLivrosAPI.Dtos;

public class ReadLivroDto
{
    public string Titulo { get; set; }
    public ReadGeneroDto Genero { get; set; }
    public string Autor { get; set; }
    public int QntPag { get; set; }
}
