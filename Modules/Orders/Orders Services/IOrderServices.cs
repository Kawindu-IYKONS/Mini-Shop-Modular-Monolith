
using Mini_Shop.Modules.Orders.Orders_DTO_s;

namespace Mini_Shop.Modules.Orders.Orders_Services
{
    public interface IOrderServices
    {
        GetOrderDto CreateOrder(CreateOrderDto createOrderDto);

        List<GetOrderDto> GetOrderByUserId(int userId);
    }
}
