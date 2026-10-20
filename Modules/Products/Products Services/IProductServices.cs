
using Mini_Shop.Modulers.Products.Products_DTO_s;

namespace Mini_Shop.Modulers.Products.Products_Services
{
    public interface IProductServices
    {
        GetProductDto CreateProduct(CreateProductDto createProductDto);
        List<GetProductDto> GetAllProduct();
        GetProductDto GetProductById(int id);
        void ReduceProduct(int productId, int quantity);
    }
}
