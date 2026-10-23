
using Mini_Shop.Modules.Orders.Dtos;

namespace Mini_Shop.Modules.Orders.Services
{
    public interface IOrderServices
    {
        GetOrderDto CreateOrder(CreateOrderDto createOrderDto);

        List<GetOrderDto> GetOrderByUserId(int userId);
    }
}
