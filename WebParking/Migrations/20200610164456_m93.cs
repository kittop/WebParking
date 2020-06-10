using Microsoft.EntityFrameworkCore.Migrations;

namespace WebParking.Migrations
{
    public partial class m93 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CheckInOuts_ResponsibleId",
                table: "CheckInOuts",
                column: "ResponsibleId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckInOuts_AspNetUsers_ResponsibleId",
                table: "CheckInOuts",
                column: "ResponsibleId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckInOuts_AspNetUsers_ResponsibleId",
                table: "CheckInOuts");

            migrationBuilder.DropIndex(
                name: "IX_CheckInOuts_ResponsibleId",
                table: "CheckInOuts");
        }
    }
}
