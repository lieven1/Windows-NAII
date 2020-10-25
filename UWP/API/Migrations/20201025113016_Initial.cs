using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reizen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reizen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Verplaatsingen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReisId = table.Column<int>(nullable: false),
                    VertrekPlaats = table.Column<string>(nullable: true),
                    Bestemming = table.Column<string>(nullable: true),
                    VertrekTijd = table.Column<DateTime>(nullable: false),
                    AankomstTijd = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verplaatsingen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Verplaatsingen_Reizen_ReisId",
                        column: x => x.ReisId,
                        principalTable: "Reizen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Reizen",
                columns: new[] { "Id", "Naam" },
                values: new object[] { 1, "Barcelona" });

            migrationBuilder.InsertData(
                table: "Verplaatsingen",
                columns: new[] { "Id", "AankomstTijd", "Bestemming", "ReisId", "VertrekPlaats", "VertrekTijd" },
                values: new object[] { 1, new DateTime(2020, 12, 15, 15, 0, 0, 0, DateTimeKind.Unspecified), "Barcelona", 1, "Gent", new DateTime(2020, 12, 15, 12, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Verplaatsingen",
                columns: new[] { "Id", "AankomstTijd", "Bestemming", "ReisId", "VertrekPlaats", "VertrekTijd" },
                values: new object[] { 2, new DateTime(2020, 12, 20, 18, 0, 0, 0, DateTimeKind.Unspecified), "Gent", 1, "Barcelona", new DateTime(2020, 12, 20, 16, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Verplaatsingen_ReisId",
                table: "Verplaatsingen",
                column: "ReisId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Verplaatsingen");

            migrationBuilder.DropTable(
                name: "Reizen");
        }
    }
}
