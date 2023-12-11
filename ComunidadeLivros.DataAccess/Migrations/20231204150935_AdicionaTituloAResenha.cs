using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComunidadeLivros.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaTituloAResenha : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TituloResenha",
                table: "Resenhas",
                type: "varchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TituloResenha",
                table: "Resenhas");
        }
    }
}
