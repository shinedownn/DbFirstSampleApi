using Swashbuckle.AspNetCore.Annotations;

namespace DbFirstSampleApi.Entities.EndpointParams.Product
{
    public class CreateProductParams
    { 
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; set; } = false;
        [SwaggerIgnore]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
