using AutoMapper;
using DbFirstSampleApi.Entities.Concrete;
using DbFirstSampleApi.Entities.Dtos.UserDto;

namespace DbFirstSampleApi.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ProductEntity, GetUserDto>().ReverseMap();
            CreateMap<ProductEntity, CreateUserDto>().ReverseMap();
            CreateMap<ProductEntity, DeleteUserDto>().ReverseMap(); 
            CreateMap<ProductEntity, UpdateUserDto>().ReverseMap(); 
        }
    }
}
