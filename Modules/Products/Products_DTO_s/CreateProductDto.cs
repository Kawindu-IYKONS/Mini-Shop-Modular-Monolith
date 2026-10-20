using System.ComponentModel.DataAnnotations;

namespace Mini_Shop.Modulers.Products.Products_DTO_s
{
    public class CreateProductDto
    {
        [Required(ErrorMessage = "Product name is required.")]
        public string Name { get; set; }=string.Empty;

        [Range(typeof(decimal), "0", "79228162514264337593543950335",ErrorMessage = "Price cannot be negative.")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue,ErrorMessage = "Stock cannot be negative.")]
        public int Stock {  get; set; }
    }
}
