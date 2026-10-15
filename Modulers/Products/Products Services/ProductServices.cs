using Mini_Shop.Modulers.Products.Products_DTO_s;
using Mini_Shop.Modulers.Products.Products_Data_Store;
namespace Mini_Shop.Modulers.Products.Products_Services
{
    public class ProductServices:IProductServices
    {
        private ProductDataStore _productDataStore=new ProductDataStore();

        public GetProductDto CreateProduct(CreateProductDto createProductDto) {
            if (createProductDto.Price < 0) {
                throw new Exception("Can not Add This Product Check Price!");
            }
            if (createProductDto.Stock <= 0) {
                throw new Exception("Can not Add This Product Check Price!");
            }

            var addProduct = _productDataStore.Add(createProductDto.Name, createProductDto.Price, createProductDto.Stock);

            return new GetProductDto {
                Id=addProduct.Id,
                Name=addProduct.Name,
                Price=addProduct.Price,
                Stock=addProduct.Stock,
            };
        }

        public GetProductDto[] GetAllProduct() {

            
            return _productDataStore.GetAll().Select(p=>new GetProductDto {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock,

            }).ToArray(); 

           
        }

    }
}
