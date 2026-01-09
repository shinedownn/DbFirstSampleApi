namespace DbFirstSampleApi.Services
{
    public interface IExternalProductService
    {
        Task<IEnumerable<ExternalProduct>> GetProducts();
    }
}
