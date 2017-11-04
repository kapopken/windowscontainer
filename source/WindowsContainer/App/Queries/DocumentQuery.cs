using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;
using WindowsContainer.App.Models;
using WindowsContainer.Infrastructure;

namespace WindowsContainer.App.Queries
{
    public class DocumentQuery
    {

        public DocumentQuery(IOptions<ConfigData> config)
        {
            _config = config.Value;
            //using (var client = new HttpClient())
            //{
            //    var answer = client.GetAsync("https://172.22.220.3:10251").GetAwaiter().GetResult();

            //}
            client = new DocumentClient(new Uri(_config.CosmoUrl), _config.CosmoAuthKey);
            CreateDatabaseIfNotExistsAsync().Wait();
            CreateCollectionIfNotExistsAsync().Wait();
        }
        private string DatabaseId = "DocumentList";
        private string CollectionId = "Docs";
        private readonly ConfigData _config;
        private static DocumentClient client;

        public IQueryable<TodoDocument> GetData()
        {
            return client.CreateDocumentQuery<TodoDocument>(UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId))
                    .Where(p => p.Id == p.Id);
        }
        private async Task CreateDatabaseIfNotExistsAsync()
        {
            try
            {
                await client.ReadDatabaseAsync(UriFactory.CreateDatabaseUri(DatabaseId));
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    await client.CreateDatabaseAsync(new Database { Id = DatabaseId });
                }
                else
                {
                    throw;
                }
            }
        }

        private async Task CreateCollectionIfNotExistsAsync()
        {
            try
            {
                await client.ReadDocumentCollectionAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId));
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    await client.CreateDocumentCollectionAsync(
                        UriFactory.CreateDatabaseUri(DatabaseId),
                        new DocumentCollection { Id = CollectionId },
                        new RequestOptions { OfferThroughput = 1000 });
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
