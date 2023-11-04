using AutoMapper;
using BusinessLogic.ApiModels;
using BusinessLogic.Dtos;
using BusinessLogic.Entities;

namespace BusinessLogic.Helpers
{
    public class MapperConfigs : Profile
    {
        public MapperConfigs()
        {
            CreateMap<CreateProductModel, Product>();
            CreateMap<EditProductModel, Product>();

            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
