using AutoMapper;
using TestWeb.Data.Models;
using TestWeb.Services.Models;

namespace TestWeb.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<ProductEntity, Product>().ReverseMap();
            CreateMap<CategoryEntity, Category>().ReverseMap();

        }
    }
}
