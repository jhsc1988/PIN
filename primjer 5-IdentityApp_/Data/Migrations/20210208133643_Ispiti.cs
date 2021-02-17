using Microsoft.EntityFrameworkCore.Migrations;

namespace primjer_5_IdentityApp.Data.Migrations
{
    public partial class Ispiti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Predmet",
                table: "Ispit",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Predmet",
                table: "Ispit",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
