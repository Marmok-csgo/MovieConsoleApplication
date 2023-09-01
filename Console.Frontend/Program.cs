using MovieApp.Backend.DataLayer;
using MovieApp.Backend.Enums;
using MovieApp.Backend.Models;
using MovieApp.Backend.Services;

class Program
{
    static void Main()
    {
        //Admin: MrAke
        //password: Qwert_12345
        
        var userService = new UserService();
        
        var getUsers = userService.GetAllUsers();
        var getMovies = userService.GetAllMovies();

        //                                  Show movies
        // foreach (var movie in getMovies)
        // {
        //     Console.WriteLine(movie);
        // }

        //                                  Show Users
        // foreach (var user in getUsers)
        // {
        //     Console.WriteLine(user);
        // }


        //                                      Login
        // var userName = Console.ReadLine();
        // var password = Console.ReadLine();
        //
        // var login = password != null && userName != null && userService.Login(userName, password);
        // Console.WriteLine(login ? "You Login" : "User not found");

        //                                      Register
        // var register = userService.Register(Console.ReadLine()!, Console.ReadLine()!, Console.ReadLine()!);
        // Console.WriteLine(register ? "You Register" : "Username,email or password invalid");

        //                                      CheckAdmin and Add new Movie
        // if (userName != null && login && userService.CheckAdmin(userName))
        // {
        //     userService.AddMovie("Harry Potter I",
        //         "During World War II, a group of Allied prisoners in a German POW camp plan an ambitious escape.",
        //         new List<Genre> { Genre.Adventure, Genre.Fantasy },
        //         "John Rowley");    
        // }
        // else
        // {
        //     Console.WriteLine("Only Admin can Add Movie.");
        // }

        //                                     Search movie by title
        // var searchingMovie = Console.ReadLine();
        // var searchedMovie = userService.GetMovieByTitle(searchingMovie!);
        // foreach (var movie in searchedMovie)
        // {
        //     Console.WriteLine($"|{movie.Title}|---|{movie.Author}|---|{string.Join(",", movie.Genre)}|");
        // }

        
        //                                     Search user by username
        // var searchingUser = Console.ReadLine();
        // var searchedUser = userService.GetUsersByUseName(searchingUser!);
        // foreach (var user in searchedUser)
        // {
        //     Console.WriteLine($"|{user.UserName}|---|{user.Email}|");
        // }





    }
}