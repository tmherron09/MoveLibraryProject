using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPISample.Migrations
{
    public partial class InitialSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Movies",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Director", "Genre", "Title" },
                values: new object[,]
                {
                    { 1, "Martin Scorsese", "Drama", "The Departed" },
                    { 2, "Christopher Nolan", "Drama", "The Dark Knight" },
                    { 3, "Christopher Nolan", "Drama", "Inception" },
                    { 4, "David Gordon Green", "Comedy", "Pineapple Express" },
                    { 5, "John McTiernan", "Action", "Die Hard" },
                    { 6, "Takashii Miike", "Suspense", "Audition" },
                    { 7, "Takashii Miike", "Musical", "Happieness of the Katakuri" },
                    { 8, "Eric Till", "Comedy", "Red Green: Duct Tape Forever" },
                    { 9, "Norman Jewison", "Comedy", "Send Me No Flowers" },
                    { 10, "Joe Johnston", "Action", "Captain America: The First Avenger" },
                    { 11, "Johnathan Lynn", "Comedy", "Clue" },
                    { 12, "Stanley Donen", "Comedy", "The Grass is Greener" },
                    { 13, "JBlake Edwards", "Comedy", "Operation Petticoat" },
                    { 14, "Adam Mckay", "Comedy", "Step Brothers" },
                    { 15, "Kar-Wai Wong", "Comedy", "Fallen Angels" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 15);

            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Movies");
        }
    }
}
