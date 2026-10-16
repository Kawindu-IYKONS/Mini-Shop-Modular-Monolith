using Mini_Shop.Modulers.Orders.Orders_Data_Store;
using Mini_Shop.Modulers.Orders.Orders_DTO_s;
using Mini_Shop.Modulers.Products.Products_Services;
using Mini_Shop.Modulers.Users.Users_Services;

namespace Mini_Shop.Modulers.Orders.Orders_Services
{
    public class OrderServices:IOrderServices

    {
        private readonly OrderDataStore _store=new OrderDataStore();
        private readonly IUserServices _userServices;
        private readonly IProductServices _productServices;

        public OrderServices(IUserServices userServices, IProductServices productServices) { 
            _userServices = userServices;
            _productServices= productServices;
        }

        public GetOrderDto CreateOreder(CreateOrderDtos createOrderDtos) { 
            var checkuser=_userServices.GetUserById(createOrderDtos.UserId);
            if (checkuser == null) {
                throw new Exception("User is not registered");
            }

            _productServices.ReduceProduct(createOrderDtos.ProductId, createOrderDtos.Quantity);

            var order = _store.Add(createOrderDtos.UserId, createOrderDtos.ProductId, createOrderDtos.Quantity);

            return new GetOrderDto
            {

                OrderId = order.OrderId,
                UserId=order.UserId,
                ProductId=order.ProductId,
                OrderDate=order.OrderDate,


            };


        }

        public GetOrderDto[] GetOrderByUserId(int userId) { 
           var checkUser=_userServices.GetUserById(userId);
            if (checkUser == null) {
                throw new Exception(" This User is not registered");
            }

            return _store.GetOrderByUserId(userId).Select(o => new GetOrderDto {
                OrderId=o.OrderId,
                UserId = o.UserId,
                ProductId = o.ProductId,
                OrderDate = o.OrderDate,
            }).ToArray();
        }


    }
}
