using MovieApp.Backend.Enums;
using MovieApp.Backend.Models;

namespace MovieApp.Backend.Interface
{
    public interface IUserService
    {
        public bool Login(string username, string password);

        public bool Register(string username, string email, string password);

        public void AddMovie(string title, string desc, List<Genre> genre, string author);

        public List<User> GetAllUsers();

        public List<Movie> GetAllMovies();

        public IEnumerable<Movie> GetMovieByTitle(string title);
        
        public IEnumerable<User> GetUsersByUseName(string userName);
    }
}
