using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesTaxesAPI.Migrations
{
    public partial class BasePrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "BasePrice",
                table: "TaxableItem",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BasePrice",
                table: "TaxableItem");
        }
    }
}
