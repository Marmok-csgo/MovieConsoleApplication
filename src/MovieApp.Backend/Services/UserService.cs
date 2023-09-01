using MovieApp.Backend.DataLayer;
using MovieApp.Backend.Enums;
using MovieApp.Backend.Interface;
using MovieApp.Backend.Models;

namespace MovieApp.Backend.Services
{
    public class UserService : IUserService
    {
        public User _currentUser;
        private DataContext _dataContext;
        private Validator _validator;

        public UserService()
        {
            _currentUser = new User();
            _dataContext = new DataContext();
            _validator = new Validator();
        }

        public bool Login(string username, string password)
        {
            if (_dataContext.CheckUser(username, password))
            {
                _currentUser = _dataContext.GetUser(username, password);
                return true;
            }
            return false;
        }

        public bool Register(string username, string email, string password)
        {
            if(!_validator.IsValidUserName(username)) return false;
            if(!_validator.IsValidEmailAddress(email)) return false;
            if(_validator.IsValidPassword(password)) return false;
            if(!_validator.IsUniqueUsername(username, _dataContext.GetAllUsers())) return false;

            _dataContext.AddUser(new User(username, email, password));
            return true;
        }

        public void AddMovie(string title, string desc, List<Genre> genre, string author)
        {
            _dataContext.AddMovie(title, desc, genre, author);
        }

        public bool CheckAdmin(string username)
        {
            return _dataContext.GetAllUsers().Any(user => user.UserName == username && user.IsAdmin);
        }

        public List<User> GetAllUsers()
        {
            return _dataContext.GetAllUsers();
        }

        public List<Movie> GetAllMovies()
        {
            return _dataContext.GetAllMovies();
        }

        public IEnumerable<Movie> GetMovieByTitle(string title)
        {
            return _dataContext.GetMovieByTitle(title);
        }

        public IEnumerable<User> GetUsersByUseName(string userName)
        {
            return _dataContext.GetUsersByUseName(userName);
        }
    }
}
