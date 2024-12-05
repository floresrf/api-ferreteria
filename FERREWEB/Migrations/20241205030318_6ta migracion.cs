using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FERREWEB.Migrations
{
    /// <inheritdoc />
    public partial class _6tamigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Usuarios_idCarro",
                table: "Carros");

            migrationBuilder.CreateIndex(
                name: "IX_Carros_idUsuario",
                table: "Carros",
                column: "idUsuario",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Usuarios_idUsuario",
                table: "Carros",
                column: "idUsuario",
                principalTable: "Usuarios",
                principalColumn: "idUsuario",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Usuarios_idUsuario",
                table: "Carros");

            migrationBuilder.DropIndex(
                name: "IX_Carros_idUsuario",
                table: "Carros");

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Usuarios_idCarro",
                table: "Carros",
                column: "idCarro",
                principalTable: "Usuarios",
                principalColumn: "idUsuario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
