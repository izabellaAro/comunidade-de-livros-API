using System.ComponentModel.DataAnnotations;

namespace ComunidadeLivros.Core.Entities;

public class Autor
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public Genero GeneroAutor { get; set;} 
    public int? GeneroId { get; set; }   

    public Autor() { }

    public Autor(string nome, int generoId)
    {
        Nome = nome;
        GeneroId = generoId;
    }
}
