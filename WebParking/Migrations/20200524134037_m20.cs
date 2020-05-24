using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WebParking.Migrations
{
    public partial class m20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParkingPlace",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 15, nullable: false),
                    CategoryId = table.Column<long>(nullable: false),
                    Free = table.Column<bool>(maxLength: 20, nullable: false),
                    Notes = table.Column<string>(maxLength: 300, nullable: true),
                    Creation = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingPlace", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkingPlace_AutoCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "AutoCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParkingPlace_CategoryId",
                table: "ParkingPlace",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkingPlace");
        }
    }
}
