using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace crudBiblioteca.Models
{
    public class Acervo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Livro> Livros { get; set; }

    }
}
