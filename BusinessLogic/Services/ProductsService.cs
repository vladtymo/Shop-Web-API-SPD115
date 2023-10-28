using AutoMapper;
using BusinessLogic.ApiModels;
using BusinessLogic.Dtos;
using BusinessLogic.Exceptions;
using BusinessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ProductsService : IProductsService
    {
        private readonly Shop115DbContext ctx;
        private readonly IMapper mapper;

        public ProductsService(Shop115DbContext ctx, IMapper mapper)
        {
            this.ctx = ctx;
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

            ctx.Products.Add(mapper.Map<Product>(product));
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = ctx.Products.Find(id);

            if (item == null) throw new HttpException("Product with Id not found!", HttpStatusCode.NotFound);

            ctx.Products.Remove(item);
            ctx.SaveChanges();
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

            ctx.Products.Update(mapper.Map<Product>(product));
            ctx.SaveChanges();
        }

        public List<ProductDto> Get()
        {
            var items = ctx.Products.Include(x => x.Category).ToList();
            return mapper.Map<List<ProductDto>>(items);
        }

        public ProductDto? Get(int id)
        {
            var item = ctx.Products.Find(id);

            if (item == null) throw new HttpException("Product with Id not found!", HttpStatusCode.NotFound);

            return mapper.Map<ProductDto>(item);
        }
    }
}
