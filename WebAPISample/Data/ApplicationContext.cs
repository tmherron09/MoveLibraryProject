using Microsoft.EntityFrameworkCore;
using WebAPISample.Models;

namespace WebAPISample.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PosterImage>()
               .HasData(
               new PosterImage { PosterImageId = 1, PosterLink = "https://m.media-amazon.com/images/M/MV5BZjRlNDUxZjAtOGQ4OC00OTNlLTgxNmQtYTBmMDgwZmNmNjkxXkEyXkFqcGdeQXVyNzkwMjQ5NzM@.jpg" },
               new PosterImage { PosterImageId = 2, PosterLink = "https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@.jpg" },
               new PosterImage { PosterImageId = 3, PosterLink = "https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@.jpg" },
               new PosterImage { PosterImageId = 4, PosterLink = "https://m.media-amazon.com/images/M/MV5BMTY1MTE4NzAwM15BMl5BanBnXkFtZTcwNzg3Mjg2MQ@@.jpg" }
               );

            modelBuilder.Entity<Movie>()
             .HasData(
                new Movie { MovieId = 1, Title = "The Departed", Genre = "Drama", Director = "Martin Scorsese", PosterImageId = 1 },
                new Movie { MovieId = 2, Title = "The Dark Knight", Genre = "Drama", Director = "Christopher Nolan", PosterImageId = 2 },
                new Movie { MovieId = 3, Title = "Inception", Genre = "Drama", Director = "Christopher Nolan", PosterImageId = 3 },
                new Movie { MovieId = 4, Title = "Pineapple Express", Genre = "Comedy", Director = "David Gordon Green", PosterImageId = 4 },
                new Movie { MovieId = 5, Title = "Die Hard", Genre = "Action", Director = "John McTiernan" },
                new Movie { MovieId = 6, Title = "Audition", Genre = "Suspense", Director = "Takashii Miike" },
                new Movie { MovieId = 7, Title = "Happieness of the Katakuri", Genre = "Musical", Director = "Takashii Miike" },
                new Movie { MovieId = 8, Title = "Red Green: Duct Tape Forever", Genre = "Comedy", Director = "Eric Till" },
                new Movie { MovieId = 9, Title = "Send Me No Flowers", Genre = "Comedy", Director = "Norman Jewison" },
                new Movie { MovieId = 10, Title = "Captain America: The First Avenger", Genre = "Action", Director = "Joe Johnston" },
                new Movie { MovieId = 11, Title = "Clue", Genre = "Comedy", Director = "Johnathan Lynn" },
                new Movie { MovieId = 12, Title = "The Grass is Greener", Genre = "Comedy", Director = "Stanley Donen" },
                new Movie { MovieId = 13, Title = "Operation Petticoat", Genre = "Comedy", Director = "JBlake Edwards" },
                new Movie { MovieId = 14, Title = "Step Brothers", Genre = "Comedy", Director = "Adam Mckay" },
                new Movie { MovieId = 15, Title = "Fallen Angels", Genre = "Comedy", Director = "Kar-Wai Wong" }
             );

           

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<PosterImage> PosterImages { get; set; }
    }
}
