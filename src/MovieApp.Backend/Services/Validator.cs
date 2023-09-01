using MovieApp.Backend.Interface;
using MovieApp.Backend.Models;
using System.Text.RegularExpressions;

namespace MovieApp.Backend.Services
{
    public class Validator : IValidator
    {
        public bool IsValidEmailAddress(in string emailAddress)
        {
            return Regex.IsMatch(emailAddress, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
        }

        public bool IsValidUserName(in string username)
        {
            return Regex.IsMatch(username, @"^[a-zA-Z0-9]{4,20}$");
        }

        public bool IsValidPassword(in string password)
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#$%^&+=])(?!.*\s).{8,}$";
            return Regex.IsMatch(password, pattern);
        }

        public bool IsUniqueUsername(string username, List<User> users)
        {
            return !users.Any(x => x.UserName == username);
        }
    }
}
