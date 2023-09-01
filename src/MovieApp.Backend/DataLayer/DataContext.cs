using MovieApp.Backend.Enums;
using MovieApp.Backend.Interface;
using MovieApp.Backend.Models;
using System.Text.Json;

namespace MovieApp.Backend.DataLayer
{
    public class DataContext : ICrud
    {
        private string MoviePath = @$"{Directory.GetCurrentDirectory()}\movies.json";
        private string UsersPath = @$"{Directory.GetCurrentDirectory()}\users.json";

        public DataContext()
        {
            if (!File.Exists(MoviePath))
                File.Create(MoviePath).Close();

            if (!File.Exists(UsersPath))
                File.Create(UsersPath).Close();
        }


        public void AddUser(User user)
        {
            if (File.ReadAllText(UsersPath).Length == 0)
            {
                var _users = new List<User>();
                _users.Add(user);
                var Json = JsonSerializer.Serialize(_users);
                File.WriteAllText(UsersPath, Json);
                return;
            }
            var userList = JsonSerializer.Deserialize<List<User>>(File.ReadAllText(UsersPath));
            userList.Add(user);

            using (var writer = new StreamWriter(UsersPath))
            {
                var json = JsonSerializer.Serialize(userList);
                writer.WriteLine(json);
            }
        }

        public List<User> GetAllUsers()
        {
            if (File.ReadAllText(UsersPath).Length == 0)
            {
                return new List<User>();
            }

            var users = JsonSerializer.Deserialize<List<User>>(File.ReadAllText(UsersPath));
            return users;
        }

        public bool CheckUser(string username, string password)
        {
            return GetAllUsers()
                .Any(user => user.UserName == username && user.Password == password);
        }

        public User GetUser(string username, string password)
        {
            return GetAllUsers()
                .FirstOrDefault(x => x.UserName == username && x.Password == password);
        }

        public void AddMovie(string title, string desc, List<Genre> genre, string author)
        {
            try
            {
                var allTxt = File.ReadAllText(MoviePath);
                List<Movie> movies;

                if (string.IsNullOrWhiteSpace(allTxt))
                {
                    movies = new List<Movie>();
                }
                else
                {
                    movies = JsonSerializer.Deserialize<List<Movie>>(allTxt);
                }

                movies.Add(new Movie(title, desc, genre, author));
                File.WriteAllText(MoviePath, JsonSerializer.Serialize(movies));
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"JSON deserialization error: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"File IO error: {ex.Message}");
            }
        }


        public List<Movie> GetAllMovies()
        {
            if (File.ReadAllText(MoviePath).Length == 0)
            {
                return new List<Movie>();
            }
            var movies = JsonSerializer.Deserialize<List<Movie>>(File.ReadAllText(MoviePath));
            return movies;
            
        }
        
        public IEnumerable<Movie> GetMovieByTitle(string title)
        {
            return GetAllMovies()
                .Where(movie => movie.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
        }


        public IEnumerable<User> GetUsersByUseName(string userName)
        {
            return GetAllUsers()
                .Where(user => user.UserName.Contains(userName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
