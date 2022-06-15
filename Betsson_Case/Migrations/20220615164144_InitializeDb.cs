using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Betsson_Case.Migrations
{
    public partial class InitializeDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CsvModel",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Country = table.Column<string>(type: "text", nullable: true),
                    ItemType = table.Column<string>(type: "text", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OrderPriority = table.Column<string>(type: "text", nullable: true),
                    Region = table.Column<string>(type: "text", nullable: true),
                    SalesChannel = table.Column<string>(type: "text", nullable: true),
                    ShipDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TotalCost = table.Column<double>(type: "double precision", nullable: false),
                    TotalProfit = table.Column<double>(type: "double precision", nullable: false),
                    TotalRevenue = table.Column<double>(type: "double precision", nullable: false),
                    UnitCost = table.Column<double>(type: "double precision", nullable: false),
                    UnitPrice = table.Column<double>(type: "double precision", nullable: false),
                    UnitsSold = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CsvModel", x => x.OrderID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CsvModel");
        }
    }
}
