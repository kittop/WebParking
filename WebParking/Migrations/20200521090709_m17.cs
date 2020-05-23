using Microsoft.EntityFrameworkCore.Migrations;

namespace WebParking.Migrations
{
    public partial class m17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CategoryId",
                table: "Clients",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CategoryId",
                table: "Clients",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_ClientCategories_CategoryId",
                table: "Clients",
                column: "CategoryId",
                principalTable: "ClientCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_ClientCategories_CategoryId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_CategoryId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Clients");
        }
    }
}
