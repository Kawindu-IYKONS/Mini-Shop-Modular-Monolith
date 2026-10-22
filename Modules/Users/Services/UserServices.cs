
using Mini_Shop.Modules.Users.Dtos;
using Mini_Shop.Modules.Users.DataStore;
using Mini_Shop.Exceptions;

namespace Mini_Shop.Modules.Users.Services;

public class UserServices : IUserServices
{
    private readonly UserDataStore _userDataStore =
        new UserDataStore();

    public GetUserDto CreateUser(CreateUserDto createUserDto)
    {
        string email = createUserDto.Email.Trim();
        string username = createUserDto.UserName.Trim();

        var newUser = _userDataStore.Add(username,email);

        return new GetUserDto
        {
            Id = newUser.Id,
            UserName = newUser.UserName,
            Email = newUser.Email
        };
    }

    public GetUserDto? GetUserById(int id)
    {
        var userData = _userDataStore.GetById(id);

        if (userData == null)
        {
            throw new NotFoundException("User not found.");
        }

        return new GetUserDto
        {
            Id = userData.Id,
            UserName = userData.UserName,
            Email = userData.Email
        };
    }
}
