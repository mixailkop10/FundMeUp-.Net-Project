using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FundMeUp.Migrations
{
    public partial class skgdotnet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Backer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Profession = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Backer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectCreator",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    TrustPoints = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCreator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    StatusUpdate = table.Column<string>(nullable: true),
                    BudgetGoal = table.Column<float>(nullable: false),
                    Balance = table.Column<float>(nullable: false),
                    DoΑ = table.Column<DateTime>(nullable: false),
                    Category = table.Column<string>(nullable: true),
                    ProjectCreatorId = table.Column<int>(nullable: true),
                    Available = table.Column<bool>(nullable: false),
                    Funded = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_ProjectCreator_ProjectCreatorId",
                        column: x => x.ProjectCreatorId,
                        principalTable: "ProjectCreator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reward",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ProjectId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reward", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reward_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BackerProject",
                columns: table => new
                {
                    BackerId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    DoF = table.Column<DateTime>(nullable: false),
                    Fund = table.Column<float>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    RewardId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackerProject", x => new { x.BackerId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_BackerProject_Backer_BackerId",
                        column: x => x.BackerId,
                        principalTable: "Backer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BackerProject_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BackerProject_Reward_RewardId",
                        column: x => x.RewardId,
                        principalTable: "Reward",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BackerProject_ProjectId",
                table: "BackerProject",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_BackerProject_RewardId",
                table: "BackerProject",
                column: "RewardId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ProjectCreatorId",
                table: "Project",
                column: "ProjectCreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reward_ProjectId",
                table: "Reward",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BackerProject");

            migrationBuilder.DropTable(
                name: "Backer");

            migrationBuilder.DropTable(
                name: "Reward");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "ProjectCreator");
        }
    }
}
