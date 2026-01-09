using Swashbuckle.AspNetCore.Annotations;

namespace DbFirstSampleApi.Entities.EndpointParams.Product
{
    public class UpdateProductParams
    {
        [SwaggerIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Category { get; set; }
        public double? Price { get; set; }
        public bool? IsActive { get; set; }
    }
}
