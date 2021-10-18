using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PracticaFinal.SalasCine.Infrastructure.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "cinema");

            migrationBuilder.CreateTable(
                name: "Pelicula",
                schema: "cinema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaEstreno = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Poster = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pelicula", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalaDeCine",
                schema: "cinema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaDeCine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Actor",
                schema: "cinema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeliculaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actor_Pelicula_PeliculaId",
                        column: x => x.PeliculaId,
                        principalSchema: "cinema",
                        principalTable: "Pelicula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Genero",
                schema: "cinema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeliculaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Genero_Pelicula_PeliculaId",
                        column: x => x.PeliculaId,
                        principalSchema: "cinema",
                        principalTable: "Pelicula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PeliculaSalaDeCine",
                schema: "cinema",
                columns: table => new
                {
                    PeliculasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalasCineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculaSalaDeCine", x => new { x.PeliculasId, x.SalasCineId });
                    table.ForeignKey(
                        name: "FK_PeliculaSalaDeCine_Pelicula_PeliculasId",
                        column: x => x.PeliculasId,
                        principalSchema: "cinema",
                        principalTable: "Pelicula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeliculaSalaDeCine_SalaDeCine_SalasCineId",
                        column: x => x.SalasCineId,
                        principalSchema: "cinema",
                        principalTable: "SalaDeCine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actor_PeliculaId",
                schema: "cinema",
                table: "Actor",
                column: "PeliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_Genero_PeliculaId",
                schema: "cinema",
                table: "Genero",
                column: "PeliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_PeliculaSalaDeCine_SalasCineId",
                schema: "cinema",
                table: "PeliculaSalaDeCine",
                column: "SalasCineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actor",
                schema: "cinema");

            migrationBuilder.DropTable(
                name: "Genero",
                schema: "cinema");

            migrationBuilder.DropTable(
                name: "PeliculaSalaDeCine",
                schema: "cinema");

            migrationBuilder.DropTable(
                name: "Pelicula",
                schema: "cinema");

            migrationBuilder.DropTable(
                name: "SalaDeCine",
                schema: "cinema");
        }
    }
}
