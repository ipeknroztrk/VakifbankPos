using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VakifbankPos.Migrations
{
    public partial class migreceiver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PosReceiverId",
                table: "PosActions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PosReceivers",
                columns: table => new
                {
                    PosReceiverId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Surname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    IdentificationNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PosReceivers", x => x.PosReceiverId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PosActions_PosReceiverId",
                table: "PosActions",
                column: "PosReceiverId");

            migrationBuilder.AddForeignKey(
                name: "FK_PosActions_PosReceivers_PosReceiverId",
                table: "PosActions",
                column: "PosReceiverId",
                principalTable: "PosReceivers",
                principalColumn: "PosReceiverId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PosActions_PosReceivers_PosReceiverId",
                table: "PosActions");

            migrationBuilder.DropTable(
                name: "PosReceivers");

            migrationBuilder.DropIndex(
                name: "IX_PosActions_PosReceiverId",
                table: "PosActions");

            migrationBuilder.DropColumn(
                name: "PosReceiverId",
                table: "PosActions");
        }
    }
}
