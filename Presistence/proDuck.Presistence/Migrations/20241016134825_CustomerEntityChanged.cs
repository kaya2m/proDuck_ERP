using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proDuck.Presistence.Migrations
{
    /// <inheritdoc />
    public partial class CustomerEntityChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cities_countries_CountryId",
                schema: "public",
                table: "cities");

            migrationBuilder.DropForeignKey(
                name: "FK_districts_cities_CityId",
                schema: "public",
                table: "districts");

            migrationBuilder.DropForeignKey(
                name: "FK_districts_countries_CountryId",
                schema: "public",
                table: "districts");

            migrationBuilder.DropForeignKey(
                name: "FK_neighborhoods_cities_CityId",
                schema: "public",
                table: "neighborhoods");

            migrationBuilder.DropForeignKey(
                name: "FK_neighborhoods_countries_CountryId",
                schema: "public",
                table: "neighborhoods");

            migrationBuilder.DropForeignKey(
                name: "FK_neighborhoods_districts_DistrictId",
                schema: "public",
                table: "neighborhoods");

            migrationBuilder.RenameColumn(
                name: "NeighborhoodName",
                schema: "public",
                table: "neighborhoods",
                newName: "neighborhood_name");

            migrationBuilder.RenameColumn(
                name: "DistrictId",
                schema: "public",
                table: "neighborhoods",
                newName: "district_id");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                schema: "public",
                table: "neighborhoods",
                newName: "country_id");

            migrationBuilder.RenameColumn(
                name: "CityId",
                schema: "public",
                table: "neighborhoods",
                newName: "city_id");

            migrationBuilder.RenameColumn(
                name: "NeighborhoodId",
                schema: "public",
                table: "neighborhoods",
                newName: "neighborhood_id");

            migrationBuilder.RenameIndex(
                name: "IX_neighborhoods_DistrictId",
                schema: "public",
                table: "neighborhoods",
                newName: "IX_neighborhoods_district_id");

            migrationBuilder.RenameIndex(
                name: "IX_neighborhoods_CountryId",
                schema: "public",
                table: "neighborhoods",
                newName: "IX_neighborhoods_country_id");

            migrationBuilder.RenameIndex(
                name: "IX_neighborhoods_CityId",
                schema: "public",
                table: "neighborhoods",
                newName: "IX_neighborhoods_city_id");

            migrationBuilder.RenameColumn(
                name: "DistrictName",
                schema: "public",
                table: "districts",
                newName: "district_name");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                schema: "public",
                table: "districts",
                newName: "country_id");

            migrationBuilder.RenameColumn(
                name: "CityId",
                schema: "public",
                table: "districts",
                newName: "city_id");

            migrationBuilder.RenameColumn(
                name: "DistrictId",
                schema: "public",
                table: "districts",
                newName: "district_id");

            migrationBuilder.RenameIndex(
                name: "IX_districts_CountryId",
                schema: "public",
                table: "districts",
                newName: "IX_districts_country_id");

            migrationBuilder.RenameIndex(
                name: "IX_districts_CityId",
                schema: "public",
                table: "districts",
                newName: "IX_districts_city_id");

            migrationBuilder.RenameColumn(
                name: "CountryName",
                schema: "public",
                table: "countries",
                newName: "country_name");

            migrationBuilder.RenameColumn(
                name: "CountryDialCode",
                schema: "public",
                table: "countries",
                newName: "country_dial_code");

            migrationBuilder.RenameColumn(
                name: "CountryCode",
                schema: "public",
                table: "countries",
                newName: "country_code");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                schema: "public",
                table: "countries",
                newName: "country_id");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                schema: "public",
                table: "cities",
                newName: "country_id");

            migrationBuilder.RenameColumn(
                name: "CityName",
                schema: "public",
                table: "cities",
                newName: "city_name");

            migrationBuilder.RenameColumn(
                name: "CityId",
                schema: "public",
                table: "cities",
                newName: "city_id");

            migrationBuilder.RenameIndex(
                name: "IX_cities_CountryId",
                schema: "public",
                table: "cities",
                newName: "IX_cities_country_id");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentMethod",
                schema: "public",
                table: "customer",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "CurrencyTypes",
                schema: "public",
                table: "customer",
                type: "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_cities_countries_country_id",
                schema: "public",
                table: "cities",
                column: "country_id",
                principalSchema: "public",
                principalTable: "countries",
                principalColumn: "country_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_districts_cities_city_id",
                schema: "public",
                table: "districts",
                column: "city_id",
                principalSchema: "public",
                principalTable: "cities",
                principalColumn: "city_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_districts_countries_country_id",
                schema: "public",
                table: "districts",
                column: "country_id",
                principalSchema: "public",
                principalTable: "countries",
                principalColumn: "country_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_neighborhoods_cities_city_id",
                schema: "public",
                table: "neighborhoods",
                column: "city_id",
                principalSchema: "public",
                principalTable: "cities",
                principalColumn: "city_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_neighborhoods_countries_country_id",
                schema: "public",
                table: "neighborhoods",
                column: "country_id",
                principalSchema: "public",
                principalTable: "countries",
                principalColumn: "country_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_neighborhoods_districts_district_id",
                schema: "public",
                table: "neighborhoods",
                column: "district_id",
                principalSchema: "public",
                principalTable: "districts",
                principalColumn: "district_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cities_countries_country_id",
                schema: "public",
                table: "cities");

            migrationBuilder.DropForeignKey(
                name: "FK_districts_cities_city_id",
                schema: "public",
                table: "districts");

            migrationBuilder.DropForeignKey(
                name: "FK_districts_countries_country_id",
                schema: "public",
                table: "districts");

            migrationBuilder.DropForeignKey(
                name: "FK_neighborhoods_cities_city_id",
                schema: "public",
                table: "neighborhoods");

            migrationBuilder.DropForeignKey(
                name: "FK_neighborhoods_countries_country_id",
                schema: "public",
                table: "neighborhoods");

            migrationBuilder.DropForeignKey(
                name: "FK_neighborhoods_districts_district_id",
                schema: "public",
                table: "neighborhoods");

            migrationBuilder.DropColumn(
                name: "CurrencyTypes",
                schema: "public",
                table: "customer");

            migrationBuilder.RenameColumn(
                name: "neighborhood_name",
                schema: "public",
                table: "neighborhoods",
                newName: "NeighborhoodName");

            migrationBuilder.RenameColumn(
                name: "district_id",
                schema: "public",
                table: "neighborhoods",
                newName: "DistrictId");

            migrationBuilder.RenameColumn(
                name: "country_id",
                schema: "public",
                table: "neighborhoods",
                newName: "CountryId");

            migrationBuilder.RenameColumn(
                name: "city_id",
                schema: "public",
                table: "neighborhoods",
                newName: "CityId");

            migrationBuilder.RenameColumn(
                name: "neighborhood_id",
                schema: "public",
                table: "neighborhoods",
                newName: "NeighborhoodId");

            migrationBuilder.RenameIndex(
                name: "IX_neighborhoods_district_id",
                schema: "public",
                table: "neighborhoods",
                newName: "IX_neighborhoods_DistrictId");

            migrationBuilder.RenameIndex(
                name: "IX_neighborhoods_country_id",
                schema: "public",
                table: "neighborhoods",
                newName: "IX_neighborhoods_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_neighborhoods_city_id",
                schema: "public",
                table: "neighborhoods",
                newName: "IX_neighborhoods_CityId");

            migrationBuilder.RenameColumn(
                name: "district_name",
                schema: "public",
                table: "districts",
                newName: "DistrictName");

            migrationBuilder.RenameColumn(
                name: "country_id",
                schema: "public",
                table: "districts",
                newName: "CountryId");

            migrationBuilder.RenameColumn(
                name: "city_id",
                schema: "public",
                table: "districts",
                newName: "CityId");

            migrationBuilder.RenameColumn(
                name: "district_id",
                schema: "public",
                table: "districts",
                newName: "DistrictId");

            migrationBuilder.RenameIndex(
                name: "IX_districts_country_id",
                schema: "public",
                table: "districts",
                newName: "IX_districts_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_districts_city_id",
                schema: "public",
                table: "districts",
                newName: "IX_districts_CityId");

            migrationBuilder.RenameColumn(
                name: "country_name",
                schema: "public",
                table: "countries",
                newName: "CountryName");

            migrationBuilder.RenameColumn(
                name: "country_dial_code",
                schema: "public",
                table: "countries",
                newName: "CountryDialCode");

            migrationBuilder.RenameColumn(
                name: "country_code",
                schema: "public",
                table: "countries",
                newName: "CountryCode");

            migrationBuilder.RenameColumn(
                name: "country_id",
                schema: "public",
                table: "countries",
                newName: "CountryId");

            migrationBuilder.RenameColumn(
                name: "country_id",
                schema: "public",
                table: "cities",
                newName: "CountryId");

            migrationBuilder.RenameColumn(
                name: "city_name",
                schema: "public",
                table: "cities",
                newName: "CityName");

            migrationBuilder.RenameColumn(
                name: "city_id",
                schema: "public",
                table: "cities",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_cities_country_id",
                schema: "public",
                table: "cities",
                newName: "IX_cities_CountryId");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentMethod",
                schema: "public",
                table: "customer",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_cities_countries_CountryId",
                schema: "public",
                table: "cities",
                column: "CountryId",
                principalSchema: "public",
                principalTable: "countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_districts_cities_CityId",
                schema: "public",
                table: "districts",
                column: "CityId",
                principalSchema: "public",
                principalTable: "cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_districts_countries_CountryId",
                schema: "public",
                table: "districts",
                column: "CountryId",
                principalSchema: "public",
                principalTable: "countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_neighborhoods_cities_CityId",
                schema: "public",
                table: "neighborhoods",
                column: "CityId",
                principalSchema: "public",
                principalTable: "cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_neighborhoods_countries_CountryId",
                schema: "public",
                table: "neighborhoods",
                column: "CountryId",
                principalSchema: "public",
                principalTable: "countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_neighborhoods_districts_DistrictId",
                schema: "public",
                table: "neighborhoods",
                column: "DistrictId",
                principalSchema: "public",
                principalTable: "districts",
                principalColumn: "DistrictId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
