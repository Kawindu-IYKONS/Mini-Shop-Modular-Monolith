using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mini_Shop.Modulers.Users.Users_Services;
using Mini_Shop.Modulers.Users.Users_DTO_s;
using Microsoft.AspNetCore.Http.HttpResults;
using Mini_Shop.Modulers.Products.Products_DTO_s;
using Mini_Shop.Modulers.Products.Products_Services;



namespace Mini_Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly IProductServices _productServices;

        public MainController(IUserServices userServices,IProductServices productServices) 
        { 
            _userServices = userServices;
            _productServices = productServices;
        }

        [HttpPost("users")]
        public IActionResult CreateUser([FromBody]CreateUserDto createUserDto)
        {
            try {
                var result=_userServices.CreateUser(createUserDto);
                return Ok(result);
            }catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetUserById(int id)
        {
            try { 
                var registeredUser=_userServices.GetUserById(id);
                return Ok(registeredUser);
            } catch (Exception ex) { 
                return NotFound(ex.Message);
            }
        }

        [HttpPost("product")]
        public IActionResult CreateProduct([FromBody] CreateProductDto createProductDto)
        {
            try
            {
                var createProduct = _productServices.CreateProduct(createProductDto);
                return Ok(createProduct);
                    }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("product")]
        public IActionResult GetAllProduct() {
            try {
                var allproduct=_productServices.GetAllProduct();
                return Ok(allproduct);
            } catch {
                return BadRequest("No Any Product Yet");
            }
        }


    }
}
