namespace Mini_Shop.Modulers.Orders.Orders_DTO_s
{
    public class GetOrderDto
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }

        public int ProductId { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
