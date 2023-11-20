namespace ComunidadeLivros.Core.Entities;

public class Genero
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public Genero() { }

    public Genero(string nome)
    {
        Nome = nome;
    }
}
