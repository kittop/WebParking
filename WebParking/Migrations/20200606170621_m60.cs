using Microsoft.EntityFrameworkCore.Migrations;

namespace WebParking.Migrations
{
    public partial class m60 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Responsible",
                table: "Tariffies");

            migrationBuilder.DropColumn(
                name: "Responsible",
                table: "ClientCategories");

            migrationBuilder.DropColumn(
                name: "Responsible",
                table: "CarCategories");

            migrationBuilder.AddColumn<string>(
                name: "ResponsibleId",
                table: "Tariffies",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ResponsibleId",
                table: "ParkingPlaces",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ResponsibleId",
                table: "Clients",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ResponsibleId",
                table: "Cars",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Tariffies_ResponsibleId",
                table: "Tariffies",
                column: "ResponsibleId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingPlaces_ResponsibleId",
                table: "ParkingPlaces",
                column: "ResponsibleId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ResponsibleId",
                table: "Clients",
                column: "ResponsibleId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientCategories_ResponsibleId",
                table: "ClientCategories",
                column: "ResponsibleId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ResponsibleId",
                table: "Cars",
                column: "ResponsibleId");

            migrationBuilder.CreateIndex(
                name: "IX_CarCategories_ResponsibleId",
                table: "CarCategories",
                column: "ResponsibleId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarCategories_AspNetUsers_ResponsibleId",
                table: "CarCategories",
                column: "ResponsibleId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_AspNetUsers_ResponsibleId",
                table: "Cars",
                column: "ResponsibleId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCategories_AspNetUsers_ResponsibleId",
                table: "ClientCategories",
                column: "ResponsibleId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_AspNetUsers_ResponsibleId",
                table: "Clients",
                column: "ResponsibleId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingPlaces_AspNetUsers_ResponsibleId",
                table: "ParkingPlaces",
                column: "ResponsibleId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tariffies_AspNetUsers_ResponsibleId",
                table: "Tariffies",
                column: "ResponsibleId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarCategories_AspNetUsers_ResponsibleId",
                table: "CarCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_AspNetUsers_ResponsibleId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientCategories_AspNetUsers_ResponsibleId",
                table: "ClientCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_AspNetUsers_ResponsibleId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_ParkingPlaces_AspNetUsers_ResponsibleId",
                table: "ParkingPlaces");

            migrationBuilder.DropForeignKey(
                name: "FK_Tariffies_AspNetUsers_ResponsibleId",
                table: "Tariffies");

            migrationBuilder.DropIndex(
                name: "IX_Tariffies_ResponsibleId",
                table: "Tariffies");

            migrationBuilder.DropIndex(
                name: "IX_ParkingPlaces_ResponsibleId",
                table: "ParkingPlaces");

            migrationBuilder.DropIndex(
                name: "IX_Clients_ResponsibleId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_ClientCategories_ResponsibleId",
                table: "ClientCategories");

            migrationBuilder.DropIndex(
                name: "IX_Cars_ResponsibleId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_CarCategories_ResponsibleId",
                table: "CarCategories");

            migrationBuilder.DropColumn(
                name: "ResponsibleId",
                table: "Tariffies");

            migrationBuilder.DropColumn(
                name: "ResponsibleId",
                table: "ParkingPlaces");

            migrationBuilder.DropColumn(
                name: "ResponsibleId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ResponsibleId",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "Responsible",
                table: "Tariffies",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Responsible",
                table: "ClientCategories",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Responsible",
                table: "CarCategories",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
