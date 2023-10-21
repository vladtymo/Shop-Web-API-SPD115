using BusinessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ProductsService : IProductsService
    {
        private readonly Shop115DbContext ctx;

        public ProductsService(Shop115DbContext ctx)
        {
            this.ctx = ctx;
        }
        public void Create(Product product)
        {
            ctx.Products.Add(product);
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = ctx.Products.Find(id);

            if (item == null) return;

            ctx.Products.Remove(item);
            ctx.SaveChanges();
        }

        public void Edit(Product product)
        {
            ctx.Products.Update(product);
            ctx.SaveChanges();
        }

        public List<Product> Get()
        {
            return ctx.Products.ToList();
        }

        public Product? Get(int id)
        {
            var item = ctx.Products.Find(id);

            if (item == null) return null;

            return item;
        }
    }
}
