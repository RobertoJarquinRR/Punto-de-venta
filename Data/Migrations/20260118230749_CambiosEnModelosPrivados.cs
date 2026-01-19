using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class CambiosEnModelosPrivados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Venta",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Propietario",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Producto",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Factura",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Cliente",
                newName: "Id");

            migrationBuilder.AlterColumn<decimal>(
                name: "precio",
                table: "Producto",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "REAL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Venta",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Propietario",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Producto",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Factura",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cliente",
                newName: "id");

            migrationBuilder.AlterColumn<float>(
                name: "precio",
                table: "Producto",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");
        }
    }
}
