using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RankingCovid19.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Covid19Ranking",
                columns: table => new
                {
                    CountryId = table.Column<Guid>(nullable: false),
                    ActiveCases = table.Column<long>(nullable: false),
                    RecoveredCases = table.Column<long>(nullable: false),
                    FatalCases = table.Column<long>(nullable: false),
                    RankingPosition = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Covid19Ranking", x => x.CountryId);
                    table.ForeignKey(
                        name: "FK_Countries",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Covid19Ranking");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
