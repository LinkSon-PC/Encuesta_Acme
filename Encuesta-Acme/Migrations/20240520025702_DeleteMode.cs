using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Encuesta_Acme.Migrations
{
    public partial class DeleteMode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campos_Encuestas_EncuestaId",
                table: "Campos");

            migrationBuilder.AddForeignKey(
                name: "FK_Campos_Encuestas_EncuestaId",
                table: "Campos",
                column: "EncuestaId",
                principalTable: "Encuestas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campos_Encuestas_EncuestaId",
                table: "Campos");

            migrationBuilder.AddForeignKey(
                name: "FK_Campos_Encuestas_EncuestaId",
                table: "Campos",
                column: "EncuestaId",
                principalTable: "Encuestas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
