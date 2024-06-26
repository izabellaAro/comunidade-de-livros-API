﻿using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ComunidadeLivros.Core.Entities;

public class Livro
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O título do livro é obrigátorio")]
    public string Titulo { get; set; }

    public Genero Genero { get; set; }
    public int GeneroId { get; set; }

    public Autor Autor { get; set; }
    public int AutorId { get; set; }

    [Required]
    [Range(1, 3000, ErrorMessage = "A quantidade de páginas deve ser entre 1 e 3000")]
    public int QntPag { get; set; }
    public List<Resenha> Resenhas { get; set; }
    public string ChaveImg { get; set; }  

    public Livro()
    {
        
    }

    public Livro(string titulo, int generoId, int autorId, int qntPag)
    {
        Titulo = titulo;
        GeneroId = generoId;
        AutorId = autorId;
        QntPag = qntPag;
    }

    public void AtualizaInfo(string titulo, int generoId, int autorId, int qntPag)
    {
        Titulo = titulo;
        GeneroId = generoId;
        AutorId = autorId;
        QntPag = qntPag;
    }

    public void AdicionarChaveImg(string chaveImg)
    {
        ChaveImg = chaveImg;
    }
}
