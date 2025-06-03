using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DropDownsMVC.Migrations
{
    /// <inheritdoc />
    public partial class AgregadoCampoDescripcionProducto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Descripcion",
                value: null);

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 2,
                column: "Descripcion",
                value: null);

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 3,
                column: "Descripcion",
                value: null);

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 4,
                column: "Descripcion",
                value: null);

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 5,
                column: "Descripcion",
                value: null);

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 6,
                column: "Descripcion",
                value: null);

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 7,
                column: "Descripcion",
                value: null);

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 8,
                column: "Descripcion",
                value: null);

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 9,
                column: "Descripcion",
                value: null);

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 10,
                column: "Descripcion",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Productos");
        }
    }
}
