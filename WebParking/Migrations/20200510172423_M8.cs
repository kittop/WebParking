using Microsoft.EntityFrameworkCore.Migrations;

namespace WebParking.Migrations
{
    public partial class M8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Clients_Passport",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Passport",
                table: "Clients");

            migrationBuilder.AlterColumn<string>(
                name: "Telephone",
                table: "Clients",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Clients",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Clients",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Clients",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Document",
                table: "Clients",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DocumentType",
                table: "Clients",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Document",
                table: "Clients",
                column: "Document",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Clients_Document",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Document",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "DocumentType",
                table: "Clients");

            migrationBuilder.AlterColumn<string>(
                name: "Telephone",
                table: "Clients",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 13);

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Clients",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Clients",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Clients",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AddColumn<string>(
                name: "Passport",
                table: "Clients",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Passport",
                table: "Clients",
                column: "Passport",
                unique: true);
        }
    }
}
