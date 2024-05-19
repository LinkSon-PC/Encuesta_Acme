using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Encuesta_Acme.Migrations
{
    public partial class EncuestaUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "Encuestas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Encuestas_UsuarioId",
                table: "Encuestas",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Encuestas_AspNetUsers_UsuarioId",
                table: "Encuestas",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Encuestas_AspNetUsers_UsuarioId",
                table: "Encuestas");

            migrationBuilder.DropIndex(
                name: "IX_Encuestas_UsuarioId",
                table: "Encuestas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Encuestas");
        }
    }
}
