using AutoMapper;
using BusinessLogic.ApiModels;
using BusinessLogic.Dtos;
using DataAccess.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
