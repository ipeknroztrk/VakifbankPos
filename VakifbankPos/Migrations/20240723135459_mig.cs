using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VakifbankPos.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PosInventories",
                columns: table => new
                {
                    PosId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PosMember = table.Column<string>(type: "text", nullable: false),
                    Terminal = table.Column<string>(type: "text", nullable: false),
                    SerialNumber = table.Column<string>(type: "text", nullable: false),
                    LastIssuedTo = table.Column<string>(type: "text", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Environment = table.Column<string>(type: "text", nullable: false),
                    Vendor = table.Column<string>(type: "text", nullable: false),
                    Model = table.Column<string>(type: "text", nullable: false),
                    OwnerBank = table.Column<string>(type: "text", nullable: false),
                    PosType = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PosInventories", x => x.PosId);
                });

            migrationBuilder.CreateTable(
                name: "PosActions",
                columns: table => new
                {
                    PosActionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PosId = table.Column<int>(type: "integer", nullable: false),
                    IssuedTo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IssueDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Returned = table.Column<bool>(type: "boolean", nullable: false),
                    PosInventoryPosId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PosActions", x => x.PosActionId);
                    table.ForeignKey(
                        name: "FK_PosActions_PosInventories_PosInventoryPosId",
                        column: x => x.PosInventoryPosId,
                        principalTable: "PosInventories",
                        principalColumn: "PosId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PosActions_PosInventoryPosId",
                table: "PosActions",
                column: "PosInventoryPosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PosActions");

            migrationBuilder.DropTable(
                name: "PosInventories");
        }
    }
}
