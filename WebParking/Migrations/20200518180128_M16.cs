using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System;

namespace WebParking.Migrations
{
    public partial class M16 : Migration
    {


        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auto",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Mark = table.Column<string>(maxLength: 30, nullable: false),
                    SatetNumber = table.Column<string>(maxLength: 30, nullable: false),
                    Color = table.Column<string>(maxLength: 30, nullable: false),
                    Condition = table.Column<string>(maxLength: 300, nullable: false),
                    Notes = table.Column<string>(maxLength: 300, nullable: true),
                    Creation = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AutoCategories",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Notes = table.Column<string>(maxLength: 300, nullable: true),
                    Creation = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Responsible = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoCategories", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auto");

            migrationBuilder.DropTable(
                name: "AutoCategories");
        }
    }
}
