using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Options;
using TestMusicAppServer.Common.Configurations;
using TestMusicAppServer.Track.Domain.Storages;

namespace TestMusicAppServer.Track.Infrastructure.Storages
{
    public class AudioStorage : IAudioStorage
    {
        private readonly ConnectionStringsConfig _connectionStringsConfig;
        private readonly StorageConfig _storageConfig;

        public AudioStorage(
            IOptions<ConnectionStringsConfig> connectionStringsConfig,
            IOptions<StorageConfig> storageConfig
        )
        {
            this._connectionStringsConfig = connectionStringsConfig.Value;
            this._storageConfig = storageConfig.Value;
        }

        public async Task UploadUnprocessedAudioFileAsync(string fileName, Stream content)
        {
            var container = GetContainer(_storageConfig.UnprocessedAudioFilesContainerName);

            await container.CreateIfNotExistsAsync();

            content.Seek(0, SeekOrigin.Begin);

            var blob = container.GetBlockBlobReference(fileName);
            await blob.UploadFromStreamAsync(content);
        }

        public async Task DeleteUnprocessedAudioFileAsync(string fileName)
        {
            var container = GetContainer(_storageConfig.UnprocessedAudioFilesContainerName);

            var blob = container.GetBlockBlobReference(fileName);
            await blob.DeleteIfExistsAsync();
        }

        private CloudBlobContainer GetContainer(string containerName)
        {
            var account = CloudStorageAccount.Parse(_connectionStringsConfig.TestMusicAppStorage);
            var serviceClient = account.CreateCloudBlobClient();
            var container = serviceClient.GetContainerReference(containerName);

            return container;
        }
    }
}
