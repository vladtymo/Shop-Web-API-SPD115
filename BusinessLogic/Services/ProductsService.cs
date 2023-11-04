using AutoMapper;
using BusinessLogic.ApiModels;
using BusinessLogic.Dtos;
using BusinessLogic.Entities;
using BusinessLogic.Exceptions;
using BusinessLogic.Interfaces;
using System.Net;

namespace BusinessLogic.Services
{
    public class ProductsService : IProductsService
    {
        //private readonly Shop115DbContext ctx;
        private readonly IRepository<Product> productsRepo;

        private readonly IMapper mapper;

        public ProductsService(IRepository<Product> productsRepo, IMapper mapper)
        {
            this.productsRepo = productsRepo;
            this.mapper = mapper;
        }
        public void Create(CreateProductModel product)
        {
            //var entity = new Product()
            //{
            //    Name = product.Name,
            //    Description = product.Description,
            //    CategoryId = product.CategoryId,
            //    Discount = product.Discount,
            //    ImageUrl = product.ImageUrl,
            //    InStock = product.InStock,
            //    Price = product.Price,
            //};

            productsRepo.Insert(mapper.Map<Product>(product));
            productsRepo.Save();
        }

        public void Delete(int id)
        {
            var item = productsRepo.GetByID(id);

            if (item == null) throw new HttpException("Product with Id not found!", HttpStatusCode.NotFound);

            productsRepo.Delete(item);
            productsRepo.Save();
        }

        public void Edit(EditProductModel product)
        {
            //var entity = new Product()
            //{
            //    Id = product.Id,
            //    Name = product.Name,
            //    Description = product.Description,
            //    CategoryId = product.CategoryId,
            //    Discount = product.Discount,
            //    ImageUrl = product.ImageUrl,
            //    InStock = product.InStock,
            //    Price = product.Price,
            //};
                
            productsRepo.Update(mapper.Map<Product>(product));
            productsRepo.Save();
        }

        public List<ProductDto> Get()
        {
            var items = productsRepo.Get(includeProperties: "Category");
            return mapper.Map<List<ProductDto>>(items);
        }

        public ProductDto? Get(int id)
        {
            var item = productsRepo.GetByID(id);

            if (item == null) throw new HttpException("Product with Id not found!", HttpStatusCode.NotFound);

            return mapper.Map<ProductDto>(item);
        }
    }
}
