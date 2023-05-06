using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datos.Migrations
{
    /// <inheritdoc />
    public partial class akjhsdkjashjkdasasdas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Parametros",
                table: "Parametros");

            migrationBuilder.RenameTable(
                name: "Parametros",
                newName: "Parametro");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parametro",
                table: "Parametro",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Parametro",
                table: "Parametro");

            migrationBuilder.RenameTable(
                name: "Parametro",
                newName: "Parametros");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parametros",
                table: "Parametros",
                column: "Id");
        }
    }
}
