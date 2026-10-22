
using Mini_Shop.Modules.Products.Dtos;

namespace Mini_Shop.Modules.Products.Services
{
    public interface IProductServices
    {
        GetProductDto CreateProduct(CreateProductDto createProductDto);
        List<GetProductDto> GetAllProduct();
        GetProductDto GetProductById(int id);
        void ReduceProduct(int productId, int quantity);
    }
}
