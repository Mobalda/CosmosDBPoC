using System;
using Newtonsoft.Json;

namespace CosmosDBPoC.Model
{
    public class Sale
    {
        [JsonProperty("quotes")]
        public Quote[] Quotes { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class Quote
    {
        [JsonProperty("job")]
        public Job Job { get; set; }

        [JsonProperty("id")]
        public object Id { get; set; }
    }

    public class Contract
    {
        [JsonProperty("id")]
        public object Id { get; set; }
    }

    public class Job
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("id")]
        public object Id { get; set; }
    }
}
