using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Encuesta_Acme.Migrations
{
    public partial class cambioNombreEncuestaCampoRespuesta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EncuesatCampoRespuesta_Campos_CampoId",
                table: "EncuesatCampoRespuesta");

            migrationBuilder.DropForeignKey(
                name: "FK_EncuesatCampoRespuesta_EncuestaRespuestas_EncuestaRespuestaId",
                table: "EncuesatCampoRespuesta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EncuesatCampoRespuesta",
                table: "EncuesatCampoRespuesta");

            migrationBuilder.RenameTable(
                name: "EncuesatCampoRespuesta",
                newName: "EncuestaCampoRespuesta");

            migrationBuilder.RenameIndex(
                name: "IX_EncuesatCampoRespuesta_EncuestaRespuestaId",
                table: "EncuestaCampoRespuesta",
                newName: "IX_EncuestaCampoRespuesta_EncuestaRespuestaId");

            migrationBuilder.RenameIndex(
                name: "IX_EncuesatCampoRespuesta_CampoId",
                table: "EncuestaCampoRespuesta",
                newName: "IX_EncuestaCampoRespuesta_CampoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EncuestaCampoRespuesta",
                table: "EncuestaCampoRespuesta",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EncuestaCampoRespuesta_Campos_CampoId",
                table: "EncuestaCampoRespuesta",
                column: "CampoId",
                principalTable: "Campos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EncuestaCampoRespuesta_EncuestaRespuestas_EncuestaRespuestaId",
                table: "EncuestaCampoRespuesta",
                column: "EncuestaRespuestaId",
                principalTable: "EncuestaRespuestas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EncuestaCampoRespuesta_Campos_CampoId",
                table: "EncuestaCampoRespuesta");

            migrationBuilder.DropForeignKey(
                name: "FK_EncuestaCampoRespuesta_EncuestaRespuestas_EncuestaRespuestaId",
                table: "EncuestaCampoRespuesta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EncuestaCampoRespuesta",
                table: "EncuestaCampoRespuesta");

            migrationBuilder.RenameTable(
                name: "EncuestaCampoRespuesta",
                newName: "EncuesatCampoRespuesta");

            migrationBuilder.RenameIndex(
                name: "IX_EncuestaCampoRespuesta_EncuestaRespuestaId",
                table: "EncuesatCampoRespuesta",
                newName: "IX_EncuesatCampoRespuesta_EncuestaRespuestaId");

            migrationBuilder.RenameIndex(
                name: "IX_EncuestaCampoRespuesta_CampoId",
                table: "EncuesatCampoRespuesta",
                newName: "IX_EncuesatCampoRespuesta_CampoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EncuesatCampoRespuesta",
                table: "EncuesatCampoRespuesta",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EncuesatCampoRespuesta_Campos_CampoId",
                table: "EncuesatCampoRespuesta",
                column: "CampoId",
                principalTable: "Campos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EncuesatCampoRespuesta_EncuestaRespuestas_EncuestaRespuestaId",
                table: "EncuesatCampoRespuesta",
                column: "EncuestaRespuestaId",
                principalTable: "EncuestaRespuestas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
