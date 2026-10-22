using System.ComponentModel.DataAnnotations;

namespace Mini_Shop.Modules.Users.Dtos
{
    public class CreateUserDto
    {
        [Required]
        [RegularExpression(@".*\S.*",ErrorMessage = "User name cannot contain only spaces.")]
        public string UserName { get; set; }=string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; }=string.Empty ;
    }
}
