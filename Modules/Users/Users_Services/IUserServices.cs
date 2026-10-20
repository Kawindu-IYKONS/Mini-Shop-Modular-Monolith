using Mini_Shop.Modulers.Users.Users_DTO_s;
namespace Mini_Shop.Modulers.Users.Users_Services
{
    public interface IUserServices
    {
        GetUserDto CreateUser(CreateUserDto createUserDto);
        GetUserDto? GetUserById(int id);
        
    }
}
