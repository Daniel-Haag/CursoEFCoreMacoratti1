using Microsoft.EntityFrameworkCore.Migrations;

namespace CursoEFCore_Aula1.Migrations
{
    public partial class alteracaoTabelaLivroSemAnoLancamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnoLancamento",
                table: "Livros");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Livros",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Titulo",
                table: "Livros",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AnoLancamento",
                table: "Livros",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
