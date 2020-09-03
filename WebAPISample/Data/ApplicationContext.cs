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
               new PosterImage { PosterImageId = 1, PosterLink = "https://m.media-amazon.com/images/M/MV5BMTI1MTY2OTIxNV5BMl5BanBnXkFtZTYwNjQ4NjY3._V1_UX182_CR0,0,182,268_AL_.jpg" },
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
                new Movie { MovieId = 1, Title = "The Departed", Genre = "Drama", Director = "Martin Scorsese", PosterImageId = 1, PlotSynop = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O." },
                new Movie { MovieId = 2, Title = "The Dark Knight", Genre = "Drama", Director = "Christopher Nolan", PosterImageId = 2, PlotSynop = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice." },
                new Movie { MovieId = 3, Title = "Inception", Genre = "Drama", Director = "Christopher Nolan", PosterImageId = 3, PlotSynop = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O."
                },
                new Movie { MovieId = 4, Title = "Pineapple Express", Genre = "Comedy", Director = "David Gordon Green", PosterImageId = 4, PlotSynop = "A process server and his marijuana dealer wind up on the run from hitmen and a corrupt police officer after he witnesses his dealer's boss murder a competitor while trying to serve papers on him." },
                new Movie { MovieId = 5, Title = "Die Hard", Genre = "Action", Director = "John McTiernan", PosterImageId = 5, PlotSynop = "An NYPD officer tries to save his wife and several others taken hostage by German terrorists during a Christmas party at the Nakatomi Plaza in Los Angeles." },
                new Movie { MovieId = 6, Title = "Audition", Genre = "Suspense", Director = "Takashii Miike", PosterImageId = 6, PlotSynop = "A widower takes an offer to screen girls at a special audition, arranged for him by a friend to find him a new wife. The one he fancies is not who she appears to be after all."  },
                new Movie { MovieId = 7, Title = "Happieness of the Katakuri", Genre = "Musical", Director = "Takashii Miike", PosterImageId = 7, PlotSynop = "A family moves to the country to run a rustic mountain inn when, to their horror, the customers begin befalling sudden and unlikely fates." },
                new Movie { MovieId = 8, Title = "Red Green: Duct Tape Forever", Genre = "Comedy", Director = "Eric Till", PosterImageId = 8, PlotSynop = "The residents of Possum Lodge head on a road trip to the States, hoping to win a contest and thus pay a fine." },
                new Movie { MovieId = 9, Title = "Send Me No Flowers", Genre = "Comedy", Director = "Norman Jewison", PosterImageId = 9, PlotSynop = "A hypochondriac believes he is dying and makes plans for his wife which she discovers and misunderstands." },
                new Movie { MovieId = 10, Title = "Captain America: The First Avenger", Genre = "Action", Director = "Joe Johnston", PosterImageId = 10, PlotSynop = "Steve Rogers, a rejected military soldier transforms into Captain America after taking a dose of a \"Super - Soldier serum\". But being Captain America comes at a price as he attempts to take down a war monger and a terrorist organization." },
                new Movie { MovieId = 11, Title = "Clue", Genre = "Comedy", Director = "Johnathan Lynn", PosterImageId = 11, PlotSynop = "Six guests are anonymously invited to a strange mansion for dinner, but after their host is killed, they must cooperate with the staff to identify the murderer as the bodies pile up." },
                new Movie { MovieId = 12, Title = "The Grass is Greener", Genre = "Comedy", Director = "Stanley Donen", PosterImageId = 12, PlotSynop = "Victor and Hillary are down on their luck to the point that they allow tourists to take guided tours of their castle. But Charles Delacro, a millionaire oil tycoon, visits, and takes a liking to more than the house. Soon, Hattie Durant gets involved and they have a good old fashioned love triangle." },
                new Movie { MovieId = 13, Title = "Operation Petticoat", Genre = "Comedy", Director = "JBlake Edwards", PosterImageId = 13, PlotSynop = "During World War II, a commander finds himself stuck with a decrepit (and pink) submarine, a con man executive officer, and a group of army nurses." },
                new Movie { MovieId = 14, Title = "Step Brothers", Genre = "Comedy", Director = "Adam Mckay", PosterImageId = 14, PlotSynop = "Two aimless middle-aged losers still living at home are forced against their will to become roommates when their parents marry."  },
                new Movie { MovieId = 15, Title = "Fallen Angels", Genre = "Comedy", Director = "Kar-Wai Wong", PosterImageId = 15, PlotSynop = "This Hong Kong-set crime drama follows the lives of a hitman, hoping to get out of the business, and his elusive female partner." }
             );

           

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<PosterImage> PosterImages { get; set; }
    }
}
