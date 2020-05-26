using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RankingCovid19.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Covid19Summary",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    ActiveCases = table.Column<long>(nullable: false),
                    RecoveredCases = table.Column<long>(nullable: false),
                    FatalCases = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Covid19Summary", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Covid19Summary");
        }
    }
}
