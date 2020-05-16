using Microsoft.EntityFrameworkCore.Migrations;

namespace FundMeUp.Migrations
{
    public partial class PasswordProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Backer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Backer");
        }
    }
}
