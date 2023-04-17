using Microsoft.EntityFrameworkCore;
using System;

namespace CursoEFCore_Aula1
{
    internal class Program
    {
        //Entidade
        public class Produto
        {
            public int ProdutoId { get; set; }
            public string Nome { get; set;}
            public decimal Preco { get; set; }
            public int Estoque { get; set; }
        }

        //Classe de contexto
        public class AppDbContext : DbContext
        {
            //Mapeamento da entidade para a tabela
            public DbSet<Produto> Produtos { get; set; }

            //Provedor e string de conexão
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DANIEL_HAAG\SQLEXPRESS;" +
                    "Initial Catalog=Aula1DB;Integrated Security=True");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
