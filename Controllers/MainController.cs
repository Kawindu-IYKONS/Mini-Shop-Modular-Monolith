
using Microsoft.AspNetCore.Mvc;
using Mini_Shop.Modules.Users.Users_Services;
using Mini_Shop.Modules.Users.Users_DTO_s;
using Mini_Shop.Modules.Products.Products_DTO_s;
using Mini_Shop.Modules.Products.Products_Services;
using Mini_Shop.Modules.Orders.Dtos;
using Mini_Shop.Modules.Orders.Services;



namespace Mini_Shop.Controllers
{
    [Route("api")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly IProductServices _productServices;

        private readonly IOrderServices _orderServices;

        public MainController(IUserServices userServices,IProductServices productServices,IOrderServices orderServices) 
        { 
            _userServices = userServices;
            _productServices = productServices;
            _orderServices = orderServices;
        }

        [HttpPost("users")]
        public IActionResult CreateUser([FromBody]CreateUserDto createUserDto)
        {
            
                var result=_userServices.CreateUser(createUserDto);
                return Ok(result);
           
        }

        [HttpGet("users/{id:int}")]
        public IActionResult GetUserById(int id)
        {
            
                var registeredUser=_userServices.GetUserById(id);
                return Ok(registeredUser);
           
        }

        [HttpPost("products")]
        public IActionResult CreateProduct([FromBody] CreateProductDto createProductDto)
        {
                var createProduct = _productServices.CreateProduct(createProductDto);
                return Ok(createProduct);
         }

        [HttpGet("products")]
        public IActionResult GetAllProduct() {
            
                var allproduct=_productServices.GetAllProduct();
                return Ok(allproduct);
            
        }

        [HttpGet("products/{id:int}")]
        public IActionResult GetProductById(int id) {
            var product=_productServices.GetProductById(id);
            return Ok(product);
        }

       

        [HttpPost("orders")]
        public IActionResult CreateOrder([FromBody] CreateOrderDto createOrderDto)
        {
            var createdOrder = _orderServices.CreateOrder(createOrderDto);
            return Ok(createdOrder);
        }

        [HttpGet("users/{id:int}/orders")]
        public IActionResult GetOrderByUserID(int id )
        {
            
                var UserOders=_orderServices.GetOrderByUserId(id);
                return Ok(UserOders);
            
        }


    }
}
