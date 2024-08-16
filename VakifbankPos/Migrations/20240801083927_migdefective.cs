using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VakifbankPos.Migrations
{
    public partial class migdefective : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDefective",
                table: "PosInventories",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDefective",
                table: "PosInventories");
        }
    }
}
