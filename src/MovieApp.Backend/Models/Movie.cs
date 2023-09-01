using MovieApp.Backend.Enums;

namespace MovieApp.Backend.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Genre> Genre { get; set; }
        public string Author { get; set; }


        public Movie() {}

        public Movie(string title, string desc, List<Genre> genre, string author)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = desc;
            Genre = genre;
            Author = author;
        }


        public override string ToString()
        {
            return $"{Title}|----|{Description}|----|{string.Join(",", Genre)}|----|{Author}\n\n";
        }
    }
}
