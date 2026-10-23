
using Mini_Shop.Exceptions;

namespace Mini_Shop.Modules.Users.DataStore
{
    internal class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }

    internal class UserDataStore
    {
        private readonly List<User> users = new();
        private readonly object _lock = new();
        private int nextId = 1;

        public User Add(string name, string email)
        {
            lock (_lock)
            {
                var existingUser = users.FirstOrDefault(x =>
                    string.Equals(
                        x.Email.Trim(),
                        email.Trim(),
                        StringComparison.OrdinalIgnoreCase));

                if (existingUser != null)
                {
                    throw new DuplicateEmailException("This email is already registered!");
                }

                var user = new User
                {
                    Id = nextId++,
                    UserName = name,
                    Email = email
                };

                users.Add(user);
                return user;
            }
        }

        public User? GetById(int id)
        {
            lock (_lock)
            {
                return users.FirstOrDefault(x => x.Id == id);
            }
        }
    }
}
