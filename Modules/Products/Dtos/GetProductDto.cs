namespace Mini_Shop.Modules.Products.Dtos
{
    public class GetProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }=String .Empty;

        public decimal Price { get; set; }

        public int Stock { get; set; }
    }
}
