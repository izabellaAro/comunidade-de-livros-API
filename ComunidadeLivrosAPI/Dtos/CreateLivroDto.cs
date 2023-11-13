namespace ComunidadeLivrosAPI.Dtos;

public class CreateLivroDto
{
    public string Titulo { get; set; }
    public string Genero { get; set; }
    public string Autor { get; set; }
    public int QntPag { get; set; }
}
