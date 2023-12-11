namespace ComunidadeLivros.Application.Models.Resenha;

public class CreateResenhaDto
{
    public int LivroId { get; set; }
    public string TituloResenha { get; set; }
    public string TextoResenha { get; set; }
}
