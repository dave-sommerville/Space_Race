using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Space_Race.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    DriverId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: true),
                    TournamentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.DriverId);
                });

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    TournamentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RaceWinners = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TourFirstPlaceId = table.Column<int>(type: "int", nullable: true),
                    TourFirstPlaceDriverId = table.Column<int>(type: "int", nullable: true),
                    TourSecondPlaceId = table.Column<int>(type: "int", nullable: true),
                    TourSecondPlaceDriverId = table.Column<int>(type: "int", nullable: true),
                    TourThirdPlaceId = table.Column<int>(type: "int", nullable: true),
                    TourThirdPlaceDriverId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.TournamentId);
                    table.ForeignKey(
                        name: "FK_Tournaments_Drivers_TourFirstPlaceDriverId",
                        column: x => x.TourFirstPlaceDriverId,
                        principalTable: "Drivers",
                        principalColumn: "DriverId");
                    table.ForeignKey(
                        name: "FK_Tournaments_Drivers_TourSecondPlaceDriverId",
                        column: x => x.TourSecondPlaceDriverId,
                        principalTable: "Drivers",
                        principalColumn: "DriverId");
                    table.ForeignKey(
                        name: "FK_Tournaments_Drivers_TourThirdPlaceDriverId",
                        column: x => x.TourThirdPlaceDriverId,
                        principalTable: "Drivers",
                        principalColumn: "DriverId");
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleId);
                    table.ForeignKey(
                        name: "FK_Vehicles_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "DriverId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_TournamentId",
                table: "Drivers",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_TourFirstPlaceDriverId",
                table: "Tournaments",
                column: "TourFirstPlaceDriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_TourSecondPlaceDriverId",
                table: "Tournaments",
                column: "TourSecondPlaceDriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_TourThirdPlaceDriverId",
                table: "Tournaments",
                column: "TourThirdPlaceDriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_DriverId",
                table: "Vehicles",
                column: "DriverId",
                unique: true,
                filter: "[DriverId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_Tournaments_TournamentId",
                table: "Drivers",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "TournamentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_Tournaments_TournamentId",
                table: "Drivers");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Tournaments");

            migrationBuilder.DropTable(
                name: "Drivers");
        }
    }
}
