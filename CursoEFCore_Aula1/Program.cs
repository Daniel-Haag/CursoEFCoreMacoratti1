using CursoEFCore_Aula1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CursoEFCore_Aula1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AppDbContext())
            {
                AdicionaUmProdutoViaDbSet(db);
                AlterarProdutoViaDbSet(db);
                MostrarEstadoEntidades(db);
                ExibirProdutos(db);
                SalvaAlteracoes(db);
            }

            Console.ReadLine();
        }

        private static void SalvaAlteracoes(AppDbContext db)
        {
            db.SaveChanges();
        }

        private static void AlterarProdutoViaDbSet(AppDbContext db)
        {
            var produto = db.Produtos.First();
            produto.Nome = "Produto alterado";
            //dbSet
            db.Produtos.Update(produto);
        }

        private static void AlterarProdutoSemDbSet(AppDbContext db)
        {
            var produto = db.Produtos.First();
            produto.Nome = "Produto sem dbSet";
            //Não usando dbSet
            db.Update(produto);
        }

        private static void RemoverProdutoViaDbSet(AppDbContext db)
        {
            var produto = db.Produtos.Where(x => x.Nome.Contains("Grampos")).FirstOrDefault();
            //Usando dbSet
            db.Produtos.Remove(produto);
        }

        private static void AdicionaListaDeProdutosViaDbSet(AppDbContext db)
        {
            var listaProdutos = new List<Produto>
                {
                    new Produto { Nome = "Caderno", Preco = 5.59M, Estoque = 20 },
                    new Produto { Nome = "Grampos", Preco = 7.00M, Estoque = 30 }
                };

            db.Produtos.AddRange(listaProdutos);
        }

        private static void AdicionaUmProdutoViaDbSet(AppDbContext db)
        {
            var produtoNovo = new Produto();
            produtoNovo.Nome = "Produto teste dbSet";
            produtoNovo.Preco = 3.59M;
            produtoNovo.Estoque = 10;

            //dbSet
            db.Produtos.Add(produtoNovo);

            var estadoEntidade = db.Entry(produtoNovo).State;
            Console.WriteLine($"Estado da entidade: {estadoEntidade}");
        }

        private static void MostrarEstadoEntidades(AppDbContext db)
        {
            foreach (var item in db.ChangeTracker.Entries())
            {
                Console.WriteLine(item.State);
            }
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
