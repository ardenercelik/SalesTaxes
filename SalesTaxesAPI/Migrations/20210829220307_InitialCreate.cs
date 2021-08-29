using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesTaxesAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaxableItem",
                columns: table => new
                {
                    TaxableItemId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    IsExempt = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsImported = table.Column<bool>(type: "INTEGER", nullable: false),
                    TaxRate = table.Column<double>(type: "REAL", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "date()"),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "date()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxableItem", x => x.TaxableItemId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaxableItem");
        }
    }
}
