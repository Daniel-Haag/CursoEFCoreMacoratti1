using CursoEFCore_Aula1.Migrations;
using CursoEFCore_Aula1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.XPath;

namespace CursoEFCore_Aula1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AppDbContext())
            {
                //IncluirAutor(db);
                //IncluirAutorlivro(db);
                //IncluirAutores(db);
                //IncluirAutorlivrosAddRange(db);
                //ExibirAutores(db);
                //ExibirLivrosEAutores(db);
                //ExibirAutoresESeusLivros(db);
                //IncluirVendedor(db);
                //IncluirVenda(db);
                //ExibirAutores(db);
                ExibirVendedoresESeusProdutosVendidosViaInclude(db);
                SalvaAlteracoes(db);
            }

            Console.ReadLine();
        }

        private static void ExibirVendedoresESeusProdutosVendidosViaInclude(AppDbContext db)
        {
            var vendedores = db.Vendedores.AsNoTracking().Include(x => x.Vendas).ToList();

            //todo: finalizar...
        }

        private static void ExibirVendedoresESeusProdutosVendidosSemInclude(AppDbContext db)
        {
            

            //todo: implementar...
        }

        private static void IncluirVendedor(AppDbContext db)
        {
            var vendedor1 = new Vendedor { Nome = "Vendedor 1", Nivel = "1", Salario = 1500, Setor = "Vendas produtos escolares" };
            var vendedor2 = new Vendedor { Nome = "Vendedor 2", Nivel = "2", Salario = 1500, Setor = "Vendas produtos escolares" };
            var vendedor3 = new Vendedor { Nome = "Vendedor 3", Nivel = "3", Salario = 1500, Setor = "Vendas produtos escolares" };

            db.Vendedores.Add(vendedor1);
            db.Vendedores.Add(vendedor2);
            db.Vendedores.Add(vendedor3);
        }

        private static void IncluirVenda(AppDbContext db)
        {
            var vendedorResponsavel = db.Vendedores.First();
            var produto = db.Produtos.Where(x => x.ProdutoId == 4).FirstOrDefault();

            var venda = new Venda()
            {
                Produto = produto,
                Vendedor = vendedorResponsavel,
            };

            db.Vendas.Add(venda);
        }

        private static void IncluirAutor(AppDbContext db)
        {
            var autor = new Autor { Nome = "Daniel", Sobrenome = "Haag" };
            db.Autores.Add(autor);
        }

        private static void IncluirAutores(AppDbContext db)
        {
            var autores = new List<Autor>();
            autores.Add(new Autor { Nome = "Agatha", Sobrenome = "Christie" });
            autores.Add(new Autor { Nome = "Mathew", Sobrenome = "Brian" });
            autores.Add(new Autor { Nome = "Paul", Sobrenome = "Bob" });

            db.AddRange(autores);
        }

        private static void IncluirAutorlivro(AppDbContext db)
        {
            var autorLivro = new Autor
            {
                Nome = "João",
                Sobrenome = "Da Silva",
                Livros = new List<Livro>
                {
                    new Livro{ Titulo = "Título Livro", AnoLancamento = new DateTime(1991, 11, 1) }
                }
            };

            db.Add(autorLivro);
        }

        private static void IncluirAutorlivrosAddRange(AppDbContext db)
        {
            var autor = new Autor
            {
                Nome = "Stephen",
                Sobrenome = "King"
            };

            var livros = new List<Livro>
            {
                new Livro{ Titulo = "Carrie", AnoLancamento = new DateTime(1974, 11, 1), Autor = autor },
                new Livro{ Titulo = "A Coisa", AnoLancamento = new DateTime(1986, 11, 1), Autor = autor },
                new Livro{ Titulo = "Angústia", AnoLancamento = new DateTime(1987, 11, 1), Autor = autor }
            };

            db.AddRange(livros);
        }

        private static void ExibirAutores(AppDbContext db)
        {
            var autores = db.Autores.ToList();

            foreach (var item in autores)
            {
                Console.WriteLine($"Nome: {item.Nome} {item.Sobrenome}");
            }
        }

        private static void ExibirAutoresESeusLivros(AppDbContext db)
        {
            //AsNoTracking desabilita o rastreio da consulta
            var autores = db.Autores.AsNoTracking().Include(x => x.Livros).ToList();

            foreach (var item in autores)
            {
                Console.WriteLine($"Nome: {item.Nome} {item.Sobrenome}");

                foreach (var livro in item.Livros)
                {
                    Console.WriteLine($"\t {livro.Titulo}");
                }
            }
        }

        //Consulta Projeção
        private static void ExibirLivrosEAutores(AppDbContext db)
        {
            var resultado = db.Autores.Where(x => x.Nome == "Stephen")
                .Select(x => new
                {
                    Autor = x,
                    LivrosDoAutor = x.Livros //Atribuo a propriedade de navegação para incluir a dependencia na consulta
                })
                .FirstOrDefault();

            Console.WriteLine(resultado.Autor.Nome + " " + resultado.Autor.Sobrenome);
            foreach (var livro in resultado.LivrosDoAutor)
            {
                Console.WriteLine("\t " + livro.Titulo);
            }
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
