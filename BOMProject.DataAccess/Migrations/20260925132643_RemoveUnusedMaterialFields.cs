using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BOMProject.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUnusedMaterialFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Designatör",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "ManufacturerPart",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "Supplier",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "SupplierPart",
                table: "Materials");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Designatör",
                table: "Materials",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "Materials",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ManufacturerPart",
                table: "Materials",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supplier",
                table: "Materials",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupplierPart",
                table: "Materials",
                type: "TEXT",
                nullable: true);
        }
    }
}
