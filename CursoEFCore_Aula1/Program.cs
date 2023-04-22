using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
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
                var produtoNovo = new Produto();
                produtoNovo.Nome = "Lápis";
                produtoNovo.Preco = 3.59M;
                produtoNovo.Estoque = 10;

                db.Add(produtoNovo);
                db.SaveChanges();

                ExibirProdutos(db);
            }

            Console.ReadLine();
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
