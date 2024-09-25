using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proDuck.Presistence.Migrations
{
    /// <inheritdoc />
    public partial class update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "OfferDetails");

            migrationBuilder.DropColumn(
                name: "StockNumber",
                table: "OfferDetails");

            migrationBuilder.AddColumn<string>(
                name: "OrderName",
                table: "Orders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SerialNumber",
                table: "Orders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StockNumber",
                table: "Orders",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "StockNumber",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "SerialNumber",
                table: "OfferDetails",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StockNumber",
                table: "OfferDetails",
                type: "text",
                nullable: true);
        }
    }
}
