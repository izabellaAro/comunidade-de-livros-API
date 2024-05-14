using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Transfer;
using ComunidadeLivros.Application.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace ComunidadeLivros.Application.Services.Impl
{
    public  class AmazonS3Service : IAmazonS3Service
    {
        private readonly AWSSettings configAWS;
        public BasicAWSCredentials AwsCredentials { get; set; }

        private readonly IAmazonS3 _awsS3Client;

        public AmazonS3Service(IOptions<AWSSettings> options)
        {
            configAWS = options.Value;
           
            AwsCredentials = new BasicAWSCredentials(configAWS.AwsKeyId, configAWS.AwsKeySecret);

            var config = new AmazonS3Config
            {
                RegionEndpoint = RegionEndpoint.USEast2
            };

            _awsS3Client = new AmazonS3Client(AwsCredentials, config);
        }
        
        public async Task<bool> EnviarArquivo(string bucket, string key, IFormFile arquivo)
        {
            try
            {
                using var newMemoryStream = new MemoryStream();
                arquivo.CopyTo(newMemoryStream);

                var transfereArquivo = new TransferUtility(_awsS3Client);

                await transfereArquivo.UploadAsync(new TransferUtilityUploadRequest
                {
                    InputStream = newMemoryStream,
                    Key = key,
                    BucketName = bucket,
                    ContentType = arquivo.ContentType
                });

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
