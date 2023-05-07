using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoEFCore_Aula1.Models
{
    internal class AppDbContext : DbContext
    {
        //Mapeamento da entidade para a tabela
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Venda> Vendas { get; set; }

        //Provedor e string de conexão
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DANIEL_HAAG\SQLEXPRESS;" +
                "Initial Catalog=Aula1DB;Integrated Security=True");
        }
    }
}
