using AutoMapper;
using DbFirstSampleApi.Entities.Concrete;
using DbFirstSampleApi.Entities.Dtos.ProductDto;

namespace DbFirstSampleApi.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductEntity, GetProductDto>().ReverseMap();
            CreateMap<ProductEntity, CreateProductDto>().ReverseMap();
            CreateMap<ProductEntity, DeleteProductDto>().ReverseMap();
            CreateMap<ProductEntity, UpdateProductDto>().ReverseMap();
        }
    }
}
