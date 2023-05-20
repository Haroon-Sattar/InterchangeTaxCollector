using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class TollHistoryTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interchanges_Cities_cityID",
                table: "Interchanges");

            migrationBuilder.RenameColumn(
                name: "cityID",
                table: "Interchanges",
                newName: "CityID");

            migrationBuilder.RenameIndex(
                name: "IX_Interchanges_cityID",
                table: "Interchanges",
                newName: "IX_Interchanges_CityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Interchanges_Cities_CityID",
                table: "Interchanges",
                column: "CityID",
                principalTable: "Cities",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interchanges_Cities_CityID",
                table: "Interchanges");

            migrationBuilder.RenameColumn(
                name: "CityID",
                table: "Interchanges",
                newName: "cityID");

            migrationBuilder.RenameIndex(
                name: "IX_Interchanges_CityID",
                table: "Interchanges",
                newName: "IX_Interchanges_cityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Interchanges_Cities_cityID",
                table: "Interchanges",
                column: "cityID",
                principalTable: "Cities",
                principalColumn: "Id");
        }
    }
}
