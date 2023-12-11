namespace ComunidadeLivros.Application.Models.Resenha;

public class ReadResenhaDto
{
    public int Id { get; set; }
    public int LivroId { get; set; }
    public string TituloLivro { get; set; }
    public string NomeGenero { get; set; }
    public string NomeAutor { get; set; }
    public string TextoResenha { get; set; }
    public string TituloResenha { get; set; }
}
