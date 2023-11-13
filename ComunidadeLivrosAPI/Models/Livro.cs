namespace ComunidadeLivrosAPI.Models;

public class Livro
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Genero { get; set; }
    public string Autor { get; set; }
    public int QntPag { get; set; }
}
