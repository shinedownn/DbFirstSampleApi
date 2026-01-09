using System.Text.Json.Serialization;

namespace DbFirstSampleApi.Services
{
    public class ExternalProductService: IExternalProductService
    {
        private string _baseAddress = "https://fakestoreapi.com/";
        private HttpClient _client;
        public ExternalProductService()
        {
            _client = HttpClientFactory.Create();
            _client.BaseAddress = new Uri(_baseAddress);
            var d= GetProducts().Result;
        }

        public async Task<IEnumerable<ExternalProduct>> GetProducts()
        {
            var data = await _client.GetFromJsonAsync<IEnumerable<ExternalProduct>>("products");
            return data;
        }
    }
    public class ExternalProduct
    {
        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("title")]
        public string Title { get; init; }

        [JsonPropertyName("price")]
        public decimal Price { get; init; }

        [JsonPropertyName("description")]
        public string Description { get; init; }

        [JsonPropertyName("category")]
        public string Category { get; init; }

        [JsonPropertyName("rating")]
        public Rating Rating { get; init; }
    }

    public class Rating
    {
        [JsonPropertyName("rate")]
        public double Rate { get; init; }

        [JsonPropertyName("count")]
        public int Count { get; init; }
    }
}
