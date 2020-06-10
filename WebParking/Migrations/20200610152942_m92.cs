using Microsoft.EntityFrameworkCore.Migrations;

namespace WebParking.Migrations
{
    public partial class m92 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cars_StatetNumber",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "StatetNumber",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "StateNumber",
                table: "Cars",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_StateNumber",
                table: "Cars",
                column: "StateNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cars_StateNumber",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "StateNumber",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "StatetNumber",
                table: "Cars",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_StatetNumber",
                table: "Cars",
                column: "StatetNumber",
                unique: true);
        }
    }
}
