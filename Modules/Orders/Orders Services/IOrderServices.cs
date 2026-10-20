
using Mini_Shop.Modulers.Orders.Orders_DTO_s;

namespace Mini_Shop.Modulers.Orders.Orders_Services
{
    public interface IOrderServices
    {
        GetOrderDto CreateOrder(CreateOrderDto createOrderDto);

        List<GetOrderDto> GetOrderByUserId(int userId);
    }
}
