using AutoMapper;
using TestWeb.Models;
using TestWeb.Services.Models;
using Category = TestWeb.Models.Category;
using Product = TestWeb.Models.Product;

namespace TestWeb.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Product, Models.Product>().ReverseMap();
            CreateMap<Category, Models.Category>().ReverseMap();
        }
    }
}
