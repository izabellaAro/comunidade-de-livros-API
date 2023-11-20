using System.ComponentModel.DataAnnotations;

namespace ComunidadeLivros.Core.Entities;

public class Autor
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public Autor() { }

    public Autor(string nome)
    {
        Nome = nome;
    }
}
