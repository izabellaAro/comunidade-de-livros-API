using Microsoft.AspNetCore.Http;

namespace ComunidadeLivros.Application.Models.Livro
{
    public class AddArquivoLivroDto
    {
        public int LivroId { get; set; }
        public IFormFile Arquivo { get; set; }
    }
}
