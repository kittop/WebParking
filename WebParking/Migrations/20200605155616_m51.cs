using Microsoft.EntityFrameworkCore.Migrations;

namespace WebParking.Migrations
{
    public partial class m51 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Responsible",
                table: "ClientCategories",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ResponsibleId",
                table: "ClientCategories",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Responsible",
                table: "CarCategories",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "ResponsibleId",
                table: "CarCategories",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Responsible",
                table: "ClientCategories");

            migrationBuilder.DropColumn(
                name: "ResponsibleId",
                table: "ClientCategories");

            migrationBuilder.DropColumn(
                name: "ResponsibleId",
                table: "CarCategories");

            migrationBuilder.AlterColumn<int>(
                name: "Responsible",
                table: "CarCategories",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
