using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class Actiteit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activiteit",
                columns: table => new
                {
                    ActiviteitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActiviteitBeschrijving = table.Column<string>(nullable: true),
                    StartTijd = table.Column<DateTime>(nullable: false),
                    EindTijd = table.Column<DateTime>(nullable: false),
                    ReisId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activiteit", x => x.ActiviteitId);
                    table.ForeignKey(
                        name: "FK_Activiteit_Reizen_ReisId",
                        column: x => x.ReisId,
                        principalTable: "Reizen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Checklisten",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naam = table.Column<string>(nullable: true),
                    ReisId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checklisten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Checklisten_Reizen_ReisId",
                        column: x => x.ReisId,
                        principalTable: "Reizen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CheckListItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naam = table.Column<string>(nullable: true),
                    Aantal = table.Column<int>(nullable: false),
                    Checked = table.Column<bool>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    ChecklistId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckListItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckListItems_Checklisten_ChecklistId",
                        column: x => x.ChecklistId,
                        principalTable: "Checklisten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naam = table.Column<string>(nullable: true),
                    CheckListItemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_CheckListItems_CheckListItemId",
                        column: x => x.CheckListItemId,
                        principalTable: "CheckListItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activiteit_ReisId",
                table: "Activiteit",
                column: "ReisId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CheckListItemId",
                table: "Categories",
                column: "CheckListItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Checklisten_ReisId",
                table: "Checklisten",
                column: "ReisId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckListItems_ChecklistId",
                table: "CheckListItems",
                column: "ChecklistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activiteit");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "CheckListItems");

            migrationBuilder.DropTable(
                name: "Checklisten");
        }
    }
}
