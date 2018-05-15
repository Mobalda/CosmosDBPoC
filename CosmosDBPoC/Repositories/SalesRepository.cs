using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using CosmosDBPoC.Model;


namespace CosmosDBPoC.Repositories
{
    public class SalesRepository
    {
        private static DocumentClient client;
        private const String DatabaseName = "";
        private const String ProductionSalesCollectionName = "";

        public SalesRepository()
        {
            client = new DocumentClient(new Uri(""), "");
        }

        public async Task<IEnumerable<Sale>> GetSalesAsync()
        {
            Uri collectionUri = UriFactory.CreateDocumentCollectionUri(DatabaseName, ProductionSalesCollectionName);

            IDocumentQuery<Sale> query = client.CreateDocumentQuery<Sale>(collectionUri)
                .SelectMany(s => s.Quotes.Where(q => q.Job != null && q.Job.Status != "Done" && q.Job.Status != "Touchup" && q.Job.Status != "Cancelled").Select(q => s)).AsDocumentQuery();

            List<Sale> sales = new List<Sale>();

            while (query.HasMoreResults)
            {
                FeedResponse<Sale> response = await query.ExecuteNextAsync<Sale>();
                sales.AddRange(response);
            }

            return sales;
        }
    }
}
