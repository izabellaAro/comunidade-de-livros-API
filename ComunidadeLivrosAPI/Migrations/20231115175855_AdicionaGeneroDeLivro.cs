using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComunidadeLivrosAPI.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaGeneroDeLivro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genero",
                table: "Livros");

            migrationBuilder.AddColumn<int>(
                name: "GeneroId",
                table: "Livros",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Livros_GeneroId",
                table: "Livros",
                column: "GeneroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_Generos_GeneroId",
                table: "Livros",
                column: "GeneroId",
                principalTable: "Generos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Generos_GeneroId",
                table: "Livros");

            migrationBuilder.DropIndex(
                name: "IX_Livros_GeneroId",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "GeneroId",
                table: "Livros");

            migrationBuilder.AddColumn<string>(
                name: "Genero",
                table: "Livros",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
