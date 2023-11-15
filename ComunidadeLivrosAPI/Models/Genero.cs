using System.ComponentModel.DataAnnotations;

namespace ComunidadeLivrosAPI.Models;

public class Genero
{
    [Key]
    [Required]
    public int Id { get; set; }
    public string Nome { get; set; }

    public Genero() { }

    public Genero(string nome)
    {
        Nome = nome;
    }
}
