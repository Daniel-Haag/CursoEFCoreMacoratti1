using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoEFCore_Aula1.Models
{
    internal class Livro
    {
        public int LivroId { get; set; }
        public int Titulo { get; set; }
        public int AnoLancamento { get; set; }
        public int AutorId { get; set; }
        public Autor Autor { get; set; }
    }
}
