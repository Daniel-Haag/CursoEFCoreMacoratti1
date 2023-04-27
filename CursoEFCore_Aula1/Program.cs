using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

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
            using (var db = new AppDbContext())
            {
                AdicionaUmProduto(db);

                //AdicionaListaDeProdutos(db);

                RemoverProduto(db);

                AlterarProduto(db);

                ExibirProdutos(db);

                db.SaveChanges();
            }

            Console.ReadLine();
        }

        private static void AlterarProduto(AppDbContext db)
        {
            var produto = db.Produtos.First();
            produto.Nome = "Teste usando único saveChanges()";
            //Não usando dbSet
            //db.Update(produto);
            //Usando dbSet
            db.Produtos.Update(produto);
            //db.SaveChanges();
        }

        private static void RemoverProduto(AppDbContext db)
        {
            var produto = db.Produtos.Where(x => x.Nome.Contains("Grampos")).FirstOrDefault();
            //Usando dbSet
            db.Produtos.Remove(produto);
            //db.SaveChanges();
        }

        private static void AdicionaListaDeProdutos(AppDbContext db)
        {
            var listaProdutos = new List<Produto>
                {
                    new Produto { Nome = "Caderno", Preco = 5.59M, Estoque = 20 },
                    new Produto { Nome = "Grampos", Preco = 7.00M, Estoque = 30 }
                };

            db.Produtos.AddRange(listaProdutos);
            //db.SaveChanges();
        }

        private static void AdicionaUmProduto(AppDbContext db)
        {
            var produtoNovo = new Produto();
            produtoNovo.Nome = "Produto teste usando único saveChanges";
            produtoNovo.Preco = 3.59M;
            produtoNovo.Estoque = 10;

            db.Produtos.Add(produtoNovo);
            //db.SaveChanges();
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
