using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComunidadeLivros.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaGeneroAoAutor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GeneroId",
                table: "Autores",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Autores_GeneroId",
                table: "Autores",
                column: "GeneroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Autores_Generos_GeneroId",
                table: "Autores",
                column: "GeneroId",
                principalTable: "Generos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autores_Generos_GeneroId",
                table: "Autores");

            migrationBuilder.DropIndex(
                name: "IX_Autores_GeneroId",
                table: "Autores");

            migrationBuilder.DropColumn(
                name: "GeneroId",
                table: "Autores");
        }
    }
}
