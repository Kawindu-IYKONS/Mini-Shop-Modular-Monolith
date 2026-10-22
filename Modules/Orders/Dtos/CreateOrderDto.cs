
using System.ComponentModel.DataAnnotations;

namespace Mini_Shop.Modules.Orders.Dtos
{
    public class CreateOrderDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "User ID must be greater than 0.")]
        public int UserId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Product ID must be greater than 0.")]
        public int ProductId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public int Quantity { get; set; }
    }
}
