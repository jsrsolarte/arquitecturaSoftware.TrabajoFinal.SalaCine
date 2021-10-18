using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PracticaFinal.SalasCine.Infrastructure.Migrations
{
    public partial class ManyToManyRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actor_Pelicula_PeliculaId",
                schema: "cinema",
                table: "Actor");

            migrationBuilder.DropIndex(
                name: "IX_Actor_PeliculaId",
                schema: "cinema",
                table: "Actor");

            migrationBuilder.DropColumn(
                name: "PeliculaId",
                schema: "cinema",
                table: "Actor");

            migrationBuilder.CreateTable(
                name: "ActorPelicula",
                schema: "cinema",
                columns: table => new
                {
                    ActoresId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeliculasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorPelicula", x => new { x.ActoresId, x.PeliculasId });
                    table.ForeignKey(
                        name: "FK_ActorPelicula_Actor_ActoresId",
                        column: x => x.ActoresId,
                        principalSchema: "cinema",
                        principalTable: "Actor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorPelicula_Pelicula_PeliculasId",
                        column: x => x.PeliculasId,
                        principalSchema: "cinema",
                        principalTable: "Pelicula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorPelicula_PeliculasId",
                schema: "cinema",
                table: "ActorPelicula",
                column: "PeliculasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorPelicula",
                schema: "cinema");

            migrationBuilder.AddColumn<Guid>(
                name: "PeliculaId",
                schema: "cinema",
                table: "Actor",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Actor_PeliculaId",
                schema: "cinema",
                table: "Actor",
                column: "PeliculaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Actor_Pelicula_PeliculaId",
                schema: "cinema",
                table: "Actor",
                column: "PeliculaId",
                principalSchema: "cinema",
                principalTable: "Pelicula",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
