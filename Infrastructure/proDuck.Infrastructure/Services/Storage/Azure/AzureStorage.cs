using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using proDuck.Application.Abstraction.Storage.Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Infrastructure.Services.Storage.Azure
{
    public class AzureStorage : Storage, IAzureStroage
    {
        readonly BlobServiceClient _blobServiceClient;
         BlobContainerClient _blobContainerClient;

        public AzureStorage(IConfiguration configuration)
        {
            _blobServiceClient = new(configuration["Storage:Azure"]);
        }

        public async Task DeleteAsync(string containerName, string fileName)
        {
           _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blobClient = _blobContainerClient.GetBlobClient(fileName);
            await blobClient.DeleteIfExistsAsync();
        }

        public List<string> GetFiles(string containerName)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            return _blobContainerClient.GetBlobs().Select(x => x.Name).ToList();
        }

        public bool HasFile(string containerName, string fileName)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            return _blobContainerClient.GetBlobs().Any(x => x.Name == fileName);
        }

        public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string containerName, IFormFileCollection files)
        {
            try
            {
                _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
              var existContainer = await _blobContainerClient.CreateIfNotExistsAsync();
                if(existContainer is not null)
                await _blobContainerClient.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

                List<(string fileName, string pathOrContainerName)> datas = new();
                foreach (IFormFile file in files)
                {
                    string fileNewName = await FileRenameAsync(containerName, file.Name, HasFile);

                    BlobClient blobClient = _blobContainerClient.GetBlobClient(fileNewName);
                    await blobClient.UploadAsync(file.OpenReadStream());
                    datas.Add((fileNewName, $"{containerName}/{fileNewName}"));
                }
                return datas;
            }
            catch (Exception)
            {

                throw;
            }
           
        }

    }
}
