using System.ComponentModel.DataAnnotations;

namespace ComunidadeLivrosAPI.Models;

public class Autor
{
    [Key]
    [Required]
    public int Id { get; set; }
    public string Nome { get; set; }

    public Autor() { }

    public Autor(string nome)
    {
        Nome = nome;
    }
}
