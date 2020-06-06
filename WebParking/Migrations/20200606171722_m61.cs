using Microsoft.EntityFrameworkCore.Migrations;

namespace WebParking.Migrations
{
    public partial class m61 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ClientCategories_Name",
                table: "ClientCategories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_StatetNumber",
                table: "Cars",
                column: "StatetNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarCategories_Name",
                table: "CarCategories",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ClientCategories_Name",
                table: "ClientCategories");

            migrationBuilder.DropIndex(
                name: "IX_Cars_StatetNumber",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_CarCategories_Name",
                table: "CarCategories");
        }
    }
}
