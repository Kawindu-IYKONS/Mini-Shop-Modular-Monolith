namespace Mini_Shop.Modulers.Products.Products_DTO_s
{
    public class CreateProductDto
    {
        public String Name { get; set; }=String.Empty;
        public double Price { get; set; }

        public int Stock {  get; set; }
    }
}
