using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datos.Migrations
{
    /// <inheritdoc />
    public partial class inicial4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mantenimiento_Cabania_cabaniaId",
                table: "Mantenimiento");

            migrationBuilder.RenameColumn(
                name: "cabaniaId",
                table: "Mantenimiento",
                newName: "CabaniaId");

            migrationBuilder.RenameIndex(
                name: "IX_Mantenimiento_cabaniaId",
                table: "Mantenimiento",
                newName: "IX_Mantenimiento_CabaniaId");

            migrationBuilder.AlterColumn<int>(
                name: "CabaniaId",
                table: "Mantenimiento",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Mantenimiento_Cabania_CabaniaId",
                table: "Mantenimiento",
                column: "CabaniaId",
                principalTable: "Cabania",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mantenimiento_Cabania_CabaniaId",
                table: "Mantenimiento");

            migrationBuilder.RenameColumn(
                name: "CabaniaId",
                table: "Mantenimiento",
                newName: "cabaniaId");

            migrationBuilder.RenameIndex(
                name: "IX_Mantenimiento_CabaniaId",
                table: "Mantenimiento",
                newName: "IX_Mantenimiento_cabaniaId");

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
    }
}
