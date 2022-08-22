using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoUdemy.Migrations
{
    public partial class PeliculasGenero : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PeliculasActores",
                columns: table => new
                {
                    ActoresId = table.Column<int>(type: "int", nullable: false),
                    PeliculaId = table.Column<int>(type: "int", nullable: false),
                    Orden = table.Column<int>(type: "int", nullable: false),
                    Personaje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculasActores", x => new { x.ActoresId, x.PeliculaId });
                    table.ForeignKey(
                        name: "FK_PeliculasActores_Actores_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actores",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PeliculasActores_Peliculas_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeliculasGenero",
                columns: table => new
                {
                    GeneroId = table.Column<int>(type: "int", nullable: false),
                    PeliculaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculasGenero", x => new { x.GeneroId, x.PeliculaId });
                    table.ForeignKey(
                        name: "FK_PeliculasGenero_Generos_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeliculasGenero_Peliculas_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PeliculasActores_ActorId",
                table: "PeliculasActores",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_PeliculasActores_PeliculaId",
                table: "PeliculasActores",
                column: "PeliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_PeliculasGenero_PeliculaId",
                table: "PeliculasGenero",
                column: "PeliculaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeliculasActores");

            migrationBuilder.DropTable(
                name: "PeliculasGenero");
        }
    }
}
