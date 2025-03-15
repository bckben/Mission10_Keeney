using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mission10_backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TeamName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamID);
                });

            migrationBuilder.CreateTable(
                name: "Bowlers",
                columns: table => new
                {
                    BowlerID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BowlerFirstName = table.Column<string>(type: "TEXT", nullable: false),
                    BowlerMiddleInit = table.Column<string>(type: "TEXT", nullable: true),
                    BowlerLastName = table.Column<string>(type: "TEXT", nullable: false),
                    BowlerAddress = table.Column<string>(type: "TEXT", nullable: false),
                    BowlerCity = table.Column<string>(type: "TEXT", nullable: false),
                    BowlerState = table.Column<string>(type: "TEXT", nullable: false),
                    BowlerZip = table.Column<string>(type: "TEXT", nullable: false),
                    BowlerPhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    TeamID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bowlers", x => x.BowlerID);
                    table.ForeignKey(
                        name: "FK_Bowlers_Teams_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bowlers_TeamID",
                table: "Bowlers",
                column: "TeamID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bowlers");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
