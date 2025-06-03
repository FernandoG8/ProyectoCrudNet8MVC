using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DropDownsMVC.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sucursales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SucursalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categorias_Sucursales_SucursalId",
                        column: x => x.SucursalId,
                        principalTable: "Sucursales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Sucursales",
                columns: new[] { "Id", "Direccion", "Nombre" },
                values: new object[,]
                {
                    { 1, "123 Calle Principal", "Sucursal Principal" },
                    { 2, "456 Calle Central", "Sucursal Central" },
                    { 3, "789 Calle Norte", "Sucursal Norte" }
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Nombre", "SucursalId" },
                values: new object[,]
                {
                    { 1, "Aperitivos", 1 },
                    { 2, "Plato Principal", 1 },
                    { 3, "Postres", 2 },
                    { 4, "Bebidas", 2 },
                    { 5, "Especialidades", 3 }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, 1, "Rollitos de Primavera", 4.9900000000000002 },
                    { 2, 2, "Hamburguesa Vegana", 9.9900000000000002 },
                    { 3, 3, "Tarta de Chocolate", 7.9900000000000002 },
                    { 4, 4, "Refresco de Frutas", 2.9900000000000002 },
                    { 5, 5, "Plato Especial", 12.99 },
                    { 6, 2, "Ensalada Mediterránea", 8.9900000000000002 },
                    { 7, 3, "Pastel de Queso", 6.9900000000000002 },
                    { 8, 4, "Café Espresso", 3.9900000000000002 },
                    { 9, 5, "Pizza Margarita", 10.99 },
                    { 10, 2, "Sopa de Tomate", 5.9900000000000002 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_SucursalId",
                table: "Categorias",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriaId",
                table: "Productos",
                column: "CategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Sucursales");
        }
    }
}
