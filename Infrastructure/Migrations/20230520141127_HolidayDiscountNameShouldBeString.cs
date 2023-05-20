using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class HolidayDiscountNameShouldBeString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "HolidayDiscounts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_TollHistory_InterchangeID",
                table: "TollHistory",
                column: "InterchangeID");

            migrationBuilder.AddForeignKey(
                name: "FK_TollHistory_Interchanges_InterchangeID",
                table: "TollHistory",
                column: "InterchangeID",
                principalTable: "Interchanges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TollHistory_Interchanges_InterchangeID",
                table: "TollHistory");

            migrationBuilder.DropIndex(
                name: "IX_TollHistory_InterchangeID",
                table: "TollHistory");

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "HolidayDiscounts",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
