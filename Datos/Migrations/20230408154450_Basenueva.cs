using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datos.Migrations
{
    /// <inheritdoc />
    public partial class Basenueva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mantenimiento_Cabania_cabaniaId",
                table: "Mantenimiento");

            migrationBuilder.AlterColumn<string>(
                name: "trabajador",
                table: "Mantenimiento",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "descripcion",
                table: "Mantenimiento",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "cabaniaId",
                table: "Mantenimiento",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Mantenimiento_Cabania_cabaniaId",
                table: "Mantenimiento",
                column: "cabaniaId",
                principalTable: "Cabania",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mantenimiento_Cabania_cabaniaId",
                table: "Mantenimiento");

            migrationBuilder.AlterColumn<string>(
                name: "trabajador",
                table: "Mantenimiento",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "descripcion",
                table: "Mantenimiento",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "cabaniaId",
                table: "Mantenimiento",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Mantenimiento_Cabania_cabaniaId",
                table: "Mantenimiento",
                column: "cabaniaId",
                principalTable: "Cabania",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
