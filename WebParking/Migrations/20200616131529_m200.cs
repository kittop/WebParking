using Microsoft.EntityFrameworkCore.Migrations;

namespace WebParking.Migrations
{
    public partial class m200 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Tariffies_Name",
                table: "Tariffies",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParkingPlaces_Name",
                table: "ParkingPlaces",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tariffies_Name",
                table: "Tariffies");

            migrationBuilder.DropIndex(
                name: "IX_ParkingPlaces_Name",
                table: "ParkingPlaces");
        }
    }
}
