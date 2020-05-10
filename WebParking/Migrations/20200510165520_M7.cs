using Microsoft.EntityFrameworkCore.Migrations;

namespace WebParking.Migrations
{
    public partial class M7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Clients_Passport",
                table: "Clients",
                column: "Passport",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Clients_Passport",
                table: "Clients");
        }
    }
}
