using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPISample.Migrations
{
    public partial class INIT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PosterImages",
                columns: table => new
                {
                    PosterImageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PosterLink = table.Column<string>(nullable: true),
                    ImageData = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PosterImages", x => x.PosterImageId);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: true),
                    Director = table.Column<string>(nullable: true),
                    PosterImageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_Movies_PosterImages_PosterImageId",
                        column: x => x.PosterImageId,
                        principalTable: "PosterImages",
                        principalColumn: "PosterImageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "PosterImages",
                columns: new[] { "PosterImageId", "ImageData", "PosterLink" },
                values: new object[,]
                {
                    { 1, null, "https://m.media-amazon.com/images/M/MV5BZjRlNDUxZjAtOGQ4OC00OTNlLTgxNmQtYTBmMDgwZmNmNjkxXkEyXkFqcGdeQXVyNzkwMjQ5NzM@.jpg" },
                    { 2, null, "https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@.jpg" },
                    { 3, null, "https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@.jpg" },
                    { 4, null, "https://m.media-amazon.com/images/M/MV5BMTY1MTE4NzAwM15BMl5BanBnXkFtZTcwNzg3Mjg2MQ@@.jpg" },
                    { 5, null, "https://upload.wikimedia.org/wikipedia/en/thumb/7/7e/Die_hard.jpg/220px-Die_hard.jpg" },
                    { 6, null, "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcQDYhcR0JMTbmMm_mWMWz0TLiWoQVID1OzxFpeNJFdwWeXaFfCi" },
                    { 7, null, "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcRJgAtTCY5coGTbYcV7u7mAhOF3AnqAjNgQ5p1F4U2zPgHM7OWL" },
                    { 8, null, "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcSApgxdRebrwCpfIuOfEgnt-2Z9dpzmL1AbfNL-URRMHT61sR0s" },
                    { 9, null, "https://images-na.ssl-images-amazon.com/images/I/91BzjcKK2LL._SX300_.jpg" },
                    { 10, null, "https://images-na.ssl-images-amazon.com/images/I/71GFtflAraL._SX342_.jpg" },
                    { 11, null, "https://m.media-amazon.com/images/I/71ubsh+w3SL._AC_UY218_.jpg" },
                    { 12, null, "https://images-na.ssl-images-amazon.com/images/I/81CtYSap47L._SX300_.jpg" },
                    { 13, null, "https://images-na.ssl-images-amazon.com/images/I/711v2xMuaGL._SX300_.jpg" },
                    { 14, null, "https://images-na.ssl-images-amazon.com/images/I/81SGtfOBoSL._SY445_.jpg" },
                    { 15, null, "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcTm4JbHKXxlyPZiBwzBwQVmHq91tX9OuyvHbgDuhvODcHgZcyBN" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Director", "Genre", "PosterImageId", "Title" },
                values: new object[,]
                {
                    { 1, "Martin Scorsese", "Drama", 1, "The Departed" },
                    { 2, "Christopher Nolan", "Drama", 2, "The Dark Knight" },
                    { 3, "Christopher Nolan", "Drama", 3, "Inception" },
                    { 4, "David Gordon Green", "Comedy", 4, "Pineapple Express" },
                    { 5, "John McTiernan", "Action", 5, "Die Hard" },
                    { 6, "Takashii Miike", "Suspense", 6, "Audition" },
                    { 7, "Takashii Miike", "Musical", 7, "Happieness of the Katakuri" },
                    { 8, "Eric Till", "Comedy", 8, "Red Green: Duct Tape Forever" },
                    { 9, "Norman Jewison", "Comedy", 9, "Send Me No Flowers" },
                    { 10, "Joe Johnston", "Action", 10, "Captain America: The First Avenger" },
                    { 11, "Johnathan Lynn", "Comedy", 11, "Clue" },
                    { 12, "Stanley Donen", "Comedy", 12, "The Grass is Greener" },
                    { 13, "JBlake Edwards", "Comedy", 13, "Operation Petticoat" },
                    { 14, "Adam Mckay", "Comedy", 14, "Step Brothers" },
                    { 15, "Kar-Wai Wong", "Comedy", 15, "Fallen Angels" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_PosterImageId",
                table: "Movies",
                column: "PosterImageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "PosterImages");
        }
    }
}
