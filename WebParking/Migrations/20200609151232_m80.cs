using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WebParking.Migrations
{
    public partial class m80 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CheckInOuts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CheckType = table.Column<int>(nullable: false),
                    DateCheckIn = table.Column<DateTime>(nullable: false),
                    ClientId = table.Column<long>(nullable: false),
                    CarId = table.Column<long>(nullable: false),
                    ParkingPlaceId = table.Column<long>(nullable: false),
                    DateCheckOut = table.Column<DateTime>(nullable: false),
                    TariffId = table.Column<long>(nullable: false),
                    TotalHours = table.Column<double>(nullable: false),
                    Sum = table.Column<double>(nullable: false),
                    Notes = table.Column<string>(maxLength: 300, nullable: true),
                    Creation = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    ResponsibleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckInOuts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckInOuts_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckInOuts_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckInOuts_ParkingPlaces_ParkingPlaceId",
                        column: x => x.ParkingPlaceId,
                        principalTable: "ParkingPlaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckInOuts_Tariffies_TariffId",
                        column: x => x.TariffId,
                        principalTable: "Tariffies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckInOuts_CarId",
                table: "CheckInOuts",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckInOuts_ClientId",
                table: "CheckInOuts",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckInOuts_ParkingPlaceId",
                table: "CheckInOuts",
                column: "ParkingPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckInOuts_TariffId",
                table: "CheckInOuts",
                column: "TariffId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckInOuts");
        }
    }
}
