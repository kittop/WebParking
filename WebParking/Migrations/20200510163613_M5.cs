using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebParking.Migrations
{
    public partial class M5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Creation",
                table: "Clients",
                nullable: false,
                defaultValueSql: "CURRENT_DATE",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Creation",
                table: "Clients",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "CURRENT_DATE");
        }
    }
}
