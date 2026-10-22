

using Mini_Shop.Modules.Orders.DataStore;
using Mini_Shop.Modules.Orders.Dtos;
using Mini_Shop.Modules.Products.Products_Services;
using Mini_Shop.Modules.Users.Users_Services;

namespace Mini_Shop.Modules.Orders.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly OrderDataStore _store = new();
        private readonly IUserServices _userServices;
        private readonly IProductServices _productServices;

        public OrderServices(
            IUserServices userServices,
            IProductServices productServices)
        {
            _userServices = userServices;
            _productServices = productServices;
        }

        public GetOrderDto CreateOrder(CreateOrderDto createOrderDto)
        {
            //check user and product are available or not
            _userServices.GetUserById(createOrderDto.UserId);
            _productServices.GetProductById(createOrderDto.ProductId);

            
            _productServices.ReduceProduct(
                createOrderDto.ProductId,
                createOrderDto.Quantity);

           
            var order = _store.Add(
                createOrderDto.UserId,
                createOrderDto.ProductId,
                createOrderDto.Quantity);

            return new GetOrderDto
            {
                OrderId = order.OrderId,
                UserId = order.UserId,
                ProductId = order.ProductId,
                Quantity = order.Quantity,
                OrderDate = order.OrderDate
            };
        }

        public List<GetOrderDto> GetOrderByUserId(int userId)
        {
            // check user
            _userServices.GetUserById(userId);

            return _store.GetOrderByUserId(userId)
                .Select(order => new GetOrderDto
                {
                    OrderId = order.OrderId,
                    UserId = order.UserId,
                    ProductId = order.ProductId,
                    Quantity = order.Quantity,
                    OrderDate = order.OrderDate
                })
                .ToList();
        }
    }
}
