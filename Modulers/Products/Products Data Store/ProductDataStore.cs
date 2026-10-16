namespace Mini_Shop.Modulers.Products.Products_Data_Store
{
    
        internal class Product {

            public int Id { get; set; }
            public string Name { get; set; } = String.Empty;

            public double Price { get; set; }

            public int Stock { get; set; }

        }

    internal class ProductDataStore { 

        private Product[] _products=new Product[0];
        private int nextId = 1;

        public Product Add(string name,double price,int stock) {

            var product = new Product {
                Id =nextId++,
                Name = name,
                Price = price,
                Stock = stock,
            };

            Array.Resize(ref _products,_products.Length + 1);
            _products[_products.Length-1] = product;

            return product;
        }

        public Product[] GetAll()
        {
            return _products;
        }

       public  Product? GetProductById(int id) {

            return _products.FirstOrDefault(x => x.Id == id);


        }
        public bool ReduseStock(int productid, int quantity)
        {

            var item = GetProductById(productid);
            if (item == null || item.Stock<quantity )
            {
                return false;
            }else
            {
               item.Stock -= quantity;
                return true;
            }
            
        }
    }



    

    
}
