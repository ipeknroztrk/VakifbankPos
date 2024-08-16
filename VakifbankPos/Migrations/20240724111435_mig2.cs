using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VakifbankPos.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PosActions_PosInventories_PosInventoryPosId",
                table: "PosActions");

            migrationBuilder.DropIndex(
                name: "IX_PosActions_PosInventoryPosId",
                table: "PosActions");

            migrationBuilder.DropColumn(
                name: "PosInventoryPosId",
                table: "PosActions");

            migrationBuilder.CreateIndex(
                name: "IX_PosActions_PosId",
                table: "PosActions",
                column: "PosId");

            migrationBuilder.AddForeignKey(
                name: "FK_PosActions_PosInventories_PosId",
                table: "PosActions",
                column: "PosId",
                principalTable: "PosInventories",
                principalColumn: "PosId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PosActions_PosInventories_PosId",
                table: "PosActions");

            migrationBuilder.DropIndex(
                name: "IX_PosActions_PosId",
                table: "PosActions");

            migrationBuilder.AddColumn<int>(
                name: "PosInventoryPosId",
                table: "PosActions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PosActions_PosInventoryPosId",
                table: "PosActions",
                column: "PosInventoryPosId");

            migrationBuilder.AddForeignKey(
                name: "FK_PosActions_PosInventories_PosInventoryPosId",
                table: "PosActions",
                column: "PosInventoryPosId",
                principalTable: "PosInventories",
                principalColumn: "PosId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
