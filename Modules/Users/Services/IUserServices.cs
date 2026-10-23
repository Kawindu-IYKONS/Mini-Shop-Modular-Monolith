using Mini_Shop.Modules.Users.Dtos;
namespace Mini_Shop.Modules.Users.Services
{
    public interface IUserServices
    {
        GetUserDto CreateUser(CreateUserDto createUserDto);
        GetUserDto GetUserById(int id);
        
    }
}
