namespace ComunidadeLivrosAPI.Dtos.Resenha;

public class ReadResenhaDto
{
    public int Id { get; set; }
    public int LivroId { get; set; }
    public string TextoResenha { get; set; }
}
