using ComunidadeLivrosAPI.Models;

namespace ComunidadeLivrosAPI.Dtos.Resenha;

public class CreateResenhaDto
{
    public int LivroId { get; set; }
    public string TextoResenha { get; set; }
}
