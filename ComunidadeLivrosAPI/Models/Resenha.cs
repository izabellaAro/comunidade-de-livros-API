using System.ComponentModel.DataAnnotations;

namespace ComunidadeLivrosAPI.Models;

public class Resenha
{
    [Key]
    [Required]
    public int Id { get; set; }
    public Livro Livro { get; set; }
    public int LivroId { get; set; }
    public string TextoResenha { get; set; }

    public Resenha() { }

    public Resenha(int livroId, string textoResenha)
    {
        LivroId = livroId;
        TextoResenha = textoResenha; 
    }
}
