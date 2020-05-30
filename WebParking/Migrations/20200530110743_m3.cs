using Microsoft.EntityFrameworkCore.Migrations;

namespace WebParking.Migrations
{
    public partial class m3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Cars_CarId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_CarId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Clients");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CarId",
                table: "Clients",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CarId",
                table: "Clients",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Cars_CarId",
                table: "Clients",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
