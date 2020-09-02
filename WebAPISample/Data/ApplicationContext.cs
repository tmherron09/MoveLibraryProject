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
               new PosterImage { PosterImageId = 4, PosterLink = "https://m.media-amazon.com/images/M/MV5BMTY1MTE4NzAwM15BMl5BanBnXkFtZTcwNzg3Mjg2MQ@@.jpg" },
                new PosterImage { PosterImageId = 5, PosterLink = "https://upload.wikimedia.org/wikipedia/en/thumb/7/7e/Die_hard.jpg/220px-Die_hard.jpg" },
              new PosterImage { PosterImageId = 6, PosterLink = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcQDYhcR0JMTbmMm_mWMWz0TLiWoQVID1OzxFpeNJFdwWeXaFfCi" },
              new PosterImage { PosterImageId = 7, PosterLink = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcRJgAtTCY5coGTbYcV7u7mAhOF3AnqAjNgQ5p1F4U2zPgHM7OWL" },
              new PosterImage { PosterImageId = 8, PosterLink = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcSApgxdRebrwCpfIuOfEgnt-2Z9dpzmL1AbfNL-URRMHT61sR0s" },
              new PosterImage { PosterImageId = 9, PosterLink = "https://images-na.ssl-images-amazon.com/images/I/91BzjcKK2LL._SX300_.jpg" },
              new PosterImage { PosterImageId = 10, PosterLink = "https://images-na.ssl-images-amazon.com/images/I/71GFtflAraL._SX342_.jpg" },
              new PosterImage { PosterImageId = 11, PosterLink = "https://m.media-amazon.com/images/I/71ubsh+w3SL._AC_UY218_.jpg" },
              new PosterImage { PosterImageId = 12, PosterLink = "https://images-na.ssl-images-amazon.com/images/I/81CtYSap47L._SX300_.jpg" },
              new PosterImage { PosterImageId = 13, PosterLink = "https://images-na.ssl-images-amazon.com/images/I/711v2xMuaGL._SX300_.jpg" },
              new PosterImage { PosterImageId = 14, PosterLink = "https://images-na.ssl-images-amazon.com/images/I/81SGtfOBoSL._SY445_.jpg" },
              new PosterImage { PosterImageId = 15, PosterLink = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcTm4JbHKXxlyPZiBwzBwQVmHq91tX9OuyvHbgDuhvODcHgZcyBN" });
             

            modelBuilder.Entity<Movie>()
             .HasData(
                new Movie { MovieId = 1, Title = "The Departed", Genre = "Drama", Director = "Martin Scorsese", PosterImageId = 1 },
                new Movie { MovieId = 2, Title = "The Dark Knight", Genre = "Drama", Director = "Christopher Nolan", PosterImageId = 2 },
                new Movie { MovieId = 3, Title = "Inception", Genre = "Drama", Director = "Christopher Nolan", PosterImageId = 3 },
                new Movie { MovieId = 4, Title = "Pineapple Express", Genre = "Comedy", Director = "David Gordon Green", PosterImageId = 4 },
                new Movie { MovieId = 5, Title = "Die Hard", Genre = "Action", Director = "John McTiernan", PosterImageId = 5 },
                new Movie { MovieId = 6, Title = "Audition", Genre = "Suspense", Director = "Takashii Miike", PosterImageId = 6 },
                new Movie { MovieId = 7, Title = "Happieness of the Katakuri", Genre = "Musical", Director = "Takashii Miike", PosterImageId = 7 },
                new Movie { MovieId = 8, Title = "Red Green: Duct Tape Forever", Genre = "Comedy", Director = "Eric Till", PosterImageId = 8 },
                new Movie { MovieId = 9, Title = "Send Me No Flowers", Genre = "Comedy", Director = "Norman Jewison", PosterImageId = 9 },
                new Movie { MovieId = 10, Title = "Captain America: The First Avenger", Genre = "Action", Director = "Joe Johnston", PosterImageId = 10 },
                new Movie { MovieId = 11, Title = "Clue", Genre = "Comedy", Director = "Johnathan Lynn", PosterImageId = 11},
                new Movie { MovieId = 12, Title = "The Grass is Greener", Genre = "Comedy", Director = "Stanley Donen", PosterImageId = 12},
                new Movie { MovieId = 13, Title = "Operation Petticoat", Genre = "Comedy", Director = "JBlake Edwards", PosterImageId = 13},
                new Movie { MovieId = 14, Title = "Step Brothers", Genre = "Comedy", Director = "Adam Mckay", PosterImageId = 14},
                new Movie { MovieId = 15, Title = "Fallen Angels", Genre = "Comedy", Director = "Kar-Wai Wong", PosterImageId = 15}
             );

           

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<PosterImage> PosterImages { get; set; }
    }
}
