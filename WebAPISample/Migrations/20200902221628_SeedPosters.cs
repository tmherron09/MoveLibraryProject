using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPISample.Migrations
{
    public partial class SeedPosters : Migration
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
                table: "Movies",
                columns: new[] { "MovieId", "Director", "Genre", "PosterImageId", "Title" },
                values: new object[,]
                {
                    { 5, "John McTiernan", "Action", null, "Die Hard" },
                    { 6, "Takashii Miike", "Suspense", null, "Audition" },
                    { 7, "Takashii Miike", "Musical", null, "Happieness of the Katakuri" },
                    { 8, "Eric Till", "Comedy", null, "Red Green: Duct Tape Forever" },
                    { 9, "Norman Jewison", "Comedy", null, "Send Me No Flowers" },
                    { 10, "Joe Johnston", "Action", null, "Captain America: The First Avenger" },
                    { 11, "Johnathan Lynn", "Comedy", null, "Clue" },
                    { 12, "Stanley Donen", "Comedy", null, "The Grass is Greener" },
                    { 13, "JBlake Edwards", "Comedy", null, "Operation Petticoat" },
                    { 14, "Adam Mckay", "Comedy", null, "Step Brothers" },
                    { 15, "Kar-Wai Wong", "Comedy", null, "Fallen Angels" }
                });

            migrationBuilder.InsertData(
                table: "PosterImages",
                columns: new[] { "PosterImageId", "ImageData", "PosterLink" },
                values: new object[,]
                {
                    { 1, null, "https://m.media-amazon.com/images/M/MV5BZjRlNDUxZjAtOGQ4OC00OTNlLTgxNmQtYTBmMDgwZmNmNjkxXkEyXkFqcGdeQXVyNzkwMjQ5NzM@.jpg" },
                    { 2, null, "https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@.jpg" },
                    { 3, null, "https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@.jpg" },
                    { 4, null, "https://m.media-amazon.com/images/M/MV5BMTY1MTE4NzAwM15BMl5BanBnXkFtZTcwNzg3Mjg2MQ@@.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Director", "Genre", "PosterImageId", "Title" },
                values: new object[,]
                {
                    { 1, "Martin Scorsese", "Drama", 1, "The Departed" },
                    { 2, "Christopher Nolan", "Drama", 2, "The Dark Knight" },
                    { 3, "Christopher Nolan", "Drama", 3, "Inception" },
                    { 4, "David Gordon Green", "Comedy", 4, "Pineapple Express" }
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
