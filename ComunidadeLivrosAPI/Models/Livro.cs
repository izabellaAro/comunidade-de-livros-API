﻿using System.ComponentModel.DataAnnotations;

namespace ComunidadeLivrosAPI.Models;

public class Livro
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O título do livro é obrigátorio")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "O gênero do filme é obrigátorio")]
    public string Genero { get; set; }

    [Required(ErrorMessage = "Informar o autor do livro é obrigátorio")]
    public string Autor { get; set; }

    [Required]
    [Range(1, 3000, ErrorMessage = "A quantidade de páginas deve ser entre 1 e 3000")]
    public int QntPag { get; set; }

    public Livro()
    {
        
    }

    public Livro(string titulo, string genero, string autor, int qntPag)
    {
        Titulo = titulo;
        Genero = genero;
        Autor = autor;
        QntPag = qntPag;
    }
}