namespace Mini_Shop.Modulers.Users.Users_Data_Store
{
    internal class User {

        public int Id { get; set; }
        public string UserName { get; set; }=String .Empty;
        public string Email { get; set; } = String .Empty;


    }
    internal class UserDataStore
    {

        private User[] users=new User[0];
        private int nextId = 1;

        public User Add(String name,String email) {
            var user = new User {
                Id=nextId++,
                UserName=name,
                Email=email
            };

            Array.Resize(ref users, users.Length+1);
            users[users.Length-1] = user;
            
            return user;
                
        }
        public User? CheckEmail(String email)
        {
            return users.FirstOrDefault(x => x.Email == email);
        }

        public User? GetById(int id) {
            return users.FirstOrDefault(x => x.Id == id);
        }

       
    }
    
}
