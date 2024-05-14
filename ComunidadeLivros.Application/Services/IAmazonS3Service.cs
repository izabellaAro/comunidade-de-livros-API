using Microsoft.AspNetCore.Http;

namespace ComunidadeLivros.Application.Services
{
    public interface IAmazonS3Service
    {
        Task<bool> EnviarArquivo(string bucket, string key, IFormFile arquivo);
    }
}
