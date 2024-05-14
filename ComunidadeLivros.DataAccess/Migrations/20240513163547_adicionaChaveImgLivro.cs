using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComunidadeLivros.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class adicionaChaveImgLivro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChaveImg",
                table: "Livros",
                type: "varchar(120)",
                maxLength: 120,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChaveImg",
                table: "Livros");
        }
    }
}
