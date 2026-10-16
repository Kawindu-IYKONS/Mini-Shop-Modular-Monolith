using Mini_Shop.Modulers.Orders.Orders_DTO_s;
namespace Mini_Shop.Modulers.Orders.Orders_Services
{
    public interface IOrderServices
    {
        public GetOrderDto CreateOreder(CreateOrderDtos createOrderDtos);

        public GetOrderDto[] GetOrderByUserId(int userId);

    }
}
