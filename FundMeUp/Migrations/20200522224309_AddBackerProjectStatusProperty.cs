using Microsoft.EntityFrameworkCore.Migrations;

namespace FundMeUp.Migrations
{
    public partial class AddBackerProjectStatusProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "BackerProject",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "BackerProject");
        }
    }
}
