using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Encuesta_Acme.Migrations
{
    public partial class Respuestas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campos_Encuestas_EncuestaId",
                table: "Campos");

            migrationBuilder.CreateTable(
                name: "EncuestaRespuestas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EncuestaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncuestaRespuestas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EncuestaRespuestas_Encuestas_EncuestaId",
                        column: x => x.EncuestaId,
                        principalTable: "Encuestas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EncuesatCampoRespuesta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EncuestaRespuestaId = table.Column<int>(type: "int", nullable: false),
                    CampoId = table.Column<int>(type: "int", nullable: false),
                    Respuesta = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncuesatCampoRespuesta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EncuesatCampoRespuesta_Campos_CampoId",
                        column: x => x.CampoId,
                        principalTable: "Campos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EncuesatCampoRespuesta_EncuestaRespuestas_EncuestaRespuestaId",
                        column: x => x.EncuestaRespuestaId,
                        principalTable: "EncuestaRespuestas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EncuesatCampoRespuesta_CampoId",
                table: "EncuesatCampoRespuesta",
                column: "CampoId");

            migrationBuilder.CreateIndex(
                name: "IX_EncuesatCampoRespuesta_EncuestaRespuestaId",
                table: "EncuesatCampoRespuesta",
                column: "EncuestaRespuestaId");

            migrationBuilder.CreateIndex(
                name: "IX_EncuestaRespuestas_EncuestaId",
                table: "EncuestaRespuestas",
                column: "EncuestaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Campos_Encuestas_EncuestaId",
                table: "Campos",
                column: "EncuestaId",
                principalTable: "Encuestas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campos_Encuestas_EncuestaId",
                table: "Campos");

            migrationBuilder.DropTable(
                name: "EncuesatCampoRespuesta");

            migrationBuilder.DropTable(
                name: "EncuestaRespuestas");

            migrationBuilder.AddForeignKey(
                name: "FK_Campos_Encuestas_EncuestaId",
                table: "Campos",
                column: "EncuestaId",
                principalTable: "Encuestas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
