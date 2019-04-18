using crudBiblioteca.Models.Enuns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace crudBiblioteca.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        [DisplayName("Gênero")]
        public Genero Genero { get; set; }
        public int Quantidade { get; set; }

        public int AcervoId { get; set; }
        [ForeignKey("AcervoId")]
        public Acervo Acervo { get; set; }
    }
}
