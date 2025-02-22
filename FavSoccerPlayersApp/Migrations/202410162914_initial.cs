using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814

namespace FavSoccerPlayersApp.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SoccerPlayers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Team = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreviousTeams = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoccerPlayers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SoccerPlayers",
                columns: new[] { "Id", "Name", "Number", "PreviousTeams", "Team" },
                values: new object[,]
                {
                    { 1, "Alphonso Davies", 19, "Vancouver Whitecaps FC", "Bayern Munich" },
                    { 2, "Atiba Hutchinson", 13, "FC Copenhagen, PSV Eindhove", "Beşiktaş" },
                    { 3, "Jonathan David", 20, "Gent", "Lille OSC" },
                    { 4, "Cyle Larin", 17, "Orlando City SC, Zulte Waregem", "Real Valladolid" },
                    { 5, "Milan Borjan", 1, "Sivasspor, Ludogorets Razgrad", "Red Star Belgrade" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SoccerPlayers");
        }
    }
}
