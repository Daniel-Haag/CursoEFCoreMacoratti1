using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoEFCore_Aula1.Models
{
    internal class Venda
    {
        public int VendaId { get; set; }
        public Vendedor Vendedor { get; set; }
        public Produto Produto { get; set; }

    }
}
