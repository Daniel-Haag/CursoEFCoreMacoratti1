using Microsoft.EntityFrameworkCore.Migrations;

namespace CursoEFCore_Aula1.Migrations
{
    public partial class estoqueParaProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Estoque",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estoque",
                table: "Produtos");
        }
    }
}
