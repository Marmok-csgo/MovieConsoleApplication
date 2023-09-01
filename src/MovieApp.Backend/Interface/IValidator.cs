using MovieApp.Backend.Models;

namespace MovieApp.Backend.Interface
{
    public interface IValidator
    {
        public bool IsValidEmailAddress(in string emailAddress);

        public bool IsValidUserName(in string username);

        public bool IsValidPassword(in string password);

        public bool IsUniqueUsername(string username, List<User> users);

    }
}
