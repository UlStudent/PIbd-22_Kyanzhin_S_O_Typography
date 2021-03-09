using Microsoft.EntityFrameworkCore.Migrations;

namespace TypographyDatabaseImplement.Migrations
{
    public partial class InitialCreateThree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Printeds");

            migrationBuilder.AddColumn<string>(
                name: "PrintedName",
                table: "Printeds",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrintedName",
                table: "Printeds");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Printeds",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
