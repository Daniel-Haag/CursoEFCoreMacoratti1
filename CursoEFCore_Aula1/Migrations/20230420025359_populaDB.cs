using Microsoft.EntityFrameworkCore.Migrations;

namespace CursoEFCore_Aula1.Migrations
{
    public partial class populaDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Produtos(Nome, Preco, Estoque)" +
                "VALUES('Caneta', 4.99, 10)");

            migrationBuilder.Sql("INSERT INTO Produtos(Nome, Preco, Estoque)" +
                "VALUES('Estojo', 6.50, 15)");

            migrationBuilder.Sql("INSERT INTO Produtos(Nome, Preco, Estoque)" +
                "VALUES('Borracha', 2.99, 25)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Produtos");
        }
    }
}
