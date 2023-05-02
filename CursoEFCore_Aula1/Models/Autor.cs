using System.Collections.Generic;

namespace CursoEFCore_Aula1.Models
{
    internal class Autor
    {
        public int AutorId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public ICollection<Livro> Livros { get; set; }
    }
}
