
using Mini_Shop.exceptions;
using Mini_Shop.Modulers.Products.Products_Data_Store;
using Mini_Shop.Modulers.Products.Products_DTO_s;
using System.ComponentModel.DataAnnotations;

namespace Mini_Shop.Modulers.Products.Products_Services
{
    public class ProductServices : IProductServices
    {
        private readonly ProductDataStore _productDataStore = new ProductDataStore();

        public GetProductDto CreateProduct(CreateProductDto createProductDto)
        {
            if (string.IsNullOrWhiteSpace(createProductDto.Name))
            {
                throw new ValidationException("Product name is required.");
            }

            if (createProductDto.Price < 0)
            {
                throw new ValidationException("Price cannot be negative.");
            }

            if (createProductDto.Stock < 0)
            {
                throw new ValidationException("Stock cannot be negative.");
            }

            var product = _productDataStore.Add(
                createProductDto.Name.Trim(),
                createProductDto.Price,
                createProductDto.Stock
            );

            return new GetProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock
            };
        }

        public List<GetProductDto> GetAllProduct()
        {
            var products = _productDataStore.GetAll();

            if (products.Count == 0)
            {
                throw new NotFoundException("No products found.");
            }

            return products
                .Select(p => new GetProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Stock = p.Stock
                })
                .ToList();
        }

        public GetProductDto GetProductById(int id)
        {
            var product = _productDataStore.GetProductById(id);

            if (product == null)
            {
                throw new NotFoundException("Product not found.");
            }

            return new GetProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock
            };
        }

        public void ReduceProduct(int productId, int quantity)
        {
            if (quantity <= 0)
            {
                throw new BusinessValidationException("Quantity must be greater than 0.");
            }

            var product = _productDataStore.GetProductById(productId);

            if (product == null)
            {
                throw new NotFoundException("Product not found.");
            }

            if (product.Stock < quantity)
            {
                throw new BusinessValidationException(
                    $"Insufficient stock. Currently available: {product.Stock}."
                );
            }

            if (!_productDataStore.ReduceStock(productId, quantity))
            {
                throw new BusinessValidationException(
                    "Unable to reduce stock. Please check the available quantity."
                );
            }
        }
    }
}
