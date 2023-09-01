namespace MovieApp.Backend.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public User(string username, string email, string password)
        {
            Id = Guid.NewGuid();
            UserName = username;
            Email = email;
            Password = password;
            IsAdmin = false;
        }

        public User()
        {
        }

        public override string ToString()
        {
            return $"|{UserName}|----|{Email}|----|{IsAdmin}|";
        }
    }
}
