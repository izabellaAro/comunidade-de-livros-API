namespace ComunidadeLivros.Core.Entities;

public class Resenha
{
    public int Id { get; set; }
    public Livro Livro { get; set; }
    public int LivroId { get; set; }
    public string TituloResenha { get; set; }
    public string TextoResenha { get; set; }

    public Resenha() { }

    public Resenha(int livroId, string textoResenha, string tituloResenha)
    {
        LivroId = livroId;
        TextoResenha = textoResenha;
        TituloResenha = tituloResenha;
    }
}
