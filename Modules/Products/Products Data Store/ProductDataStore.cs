
namespace Mini_Shop.Modules.Products.Products_Data_Store;

internal class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
}

internal class ProductDataStore
{
    private readonly List<Product> _products = new();
    private readonly object _lock = new();
    private int _nextId = 1;

    public Product Add(string name, decimal price, int stock)
    {
        lock (_lock)
        {
            var product = new Product
            {
                Id = _nextId++,
                Name = name,
                Price = price,
                Stock = stock
            };

            _products.Add(product);
            return product;
        }
    }

    public List<Product> GetAll()
    {
        lock (_lock)
        {
            return _products
                .Select(p => new Product
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Stock = p.Stock
                })
                .ToList();
        }
    }

    public Product? GetProductById(int id)
    {
        lock (_lock)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return null;
            }

            return new Product
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock
            };
        }
    }

    public bool ReduceStock(int productId, int quantity)
    {
        lock (_lock)
        {
            var product = _products.FirstOrDefault(p => p.Id == productId);

            if (product == null || product.Stock < quantity)
            {
                return false;
            }

            product.Stock -= quantity;
            return true;
        }
    }
}
