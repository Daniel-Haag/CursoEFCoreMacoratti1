using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoEFCore_Aula1.Models
{
    internal class Vendedor
    {
        public int VendedorId { get; set; }
        public string Nome { get; set; }
        public string Nivel { get; set; }
        public decimal Salario { get; set; }
        public string Setor { get; set; }
        public ICollection<Venda> Vendas { get; set; }
    }
}
