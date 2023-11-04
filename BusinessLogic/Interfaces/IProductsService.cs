using BusinessLogic.ApiModels;
using BusinessLogic.Dtos;

namespace BusinessLogic.Interfaces
{
    public interface IProductsService
    {
        List<ProductDto> Get();
        ProductDto? Get(int id);
        void Create(CreateProductModel product);
        void Edit(EditProductModel product);
        void Delete(int id);
    }
}
