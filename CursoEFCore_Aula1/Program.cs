using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

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

                //optionsBuilder
                //    .EnableSensitiveDataLogging(true)
                //    .UseLoggerFactory(new LoggerFactory().AddConsole((category, level) =>
                //    level == LogLevel.Information &&
                //    category == DbLoggerCategory.Database.Command.Name, true));

            }
        }

        static void Main(string[] args)
        {
            using (var db = new AppDbContext())
            {
                AdicionaUmProduto(db);

                AdicionaListaDeProdutos(db);

                ExibirProdutos(db);
            }

            Console.ReadLine();
        }

        private static void AdicionaListaDeProdutos(AppDbContext db)
        {
            var listaProdutos = new List<Produto>
                {
                    new Produto { Nome = "Caderno", Preco = 5.59M, Estoque = 20 },
                    new Produto { Nome = "Grampos", Preco = 7.00M, Estoque = 30 }
                };

            db.Produtos.AddRange(listaProdutos);
            db.SaveChanges();
        }

        private static void AdicionaUmProduto(AppDbContext db)
        {
            var produtoNovo = new Produto();
            produtoNovo.Nome = "Produto teste usando dbSet";
            produtoNovo.Preco = 3.59M;
            produtoNovo.Estoque = 10;

            db.Produtos.Add(produtoNovo);
            db.SaveChanges();
        }

        private static void ExibirProdutos(AppDbContext db)
        {
            var produtos = db.Produtos.ToList();

            foreach (var item in produtos)
            {
                Console.WriteLine(item.Nome + "\t" + item.Preco.ToString("c"));
            }
        }
    }
}
