using Mini_Shop.Modulers.Users.Users_DTO_s;
using Mini_Shop.Modulers.Users.Users_Data_Store;
namespace Mini_Shop.Modulers.Users.Users_Services
{
    public class UserServices:IUserServices
    {
        private readonly UserDataStore _userDataStore=new UserDataStore();

        public GetUserDto CreateUser(CreateUserDto createUserDto) {

            var registeredUser = _userDataStore.CheckEmail(createUserDto.Email.Trim());
            if (registeredUser != null)
            {
                throw new Exception("This email is already registered!");
            }
            
            var newUser= _userDataStore.Add(createUserDto.UserName,createUserDto.Email);

            return new GetUserDto
            {
                Id = newUser.Id,
                UserName = newUser.UserName,
                Email = newUser.Email,

            };
            
        }

        public GetUserDto? GetUserById(int id) {
            var userData = _userDataStore.GetById(id);

            if (userData==null) {

                throw new Exception("No Registered User");
            
            }


            return new GetUserDto
            {
                Id = userData.Id,
                UserName = userData.UserName,
                Email = userData.Email,
            };
        }
    }
}
