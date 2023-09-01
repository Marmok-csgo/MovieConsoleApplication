using MovieApp.Backend.Enums;
using MovieApp.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Backend.Interface
{
    public interface ICrud
    {
        public void AddUser(User user);

        public List<User> GetAllUsers();

        public bool CheckUser(string username, string password);

        public User GetUser(string username, string password);

        public void AddMovie(string title, string desc, List<Genre> genre, string author);

        public List<Movie> GetAllMovies();
        public IEnumerable<Movie> GetMovieByTitle(string title);

        public IEnumerable<User> GetUsersByUseName(string userName);

    }
}
