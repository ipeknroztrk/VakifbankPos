using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VakifbankPos.Migrations
{
    public partial class migımage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
               name: "ImageUrl",
               table: "PosReceivers",
               type: "text",
               nullable: false,
               defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
