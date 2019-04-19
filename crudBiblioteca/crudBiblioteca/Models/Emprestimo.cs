using crudBiblioteca.Models.Enuns;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace crudBiblioteca.Models
{
    public class Emprestimo
    {
        public int Id { get; set; }
        public List<Livro> Livros { get; set; }
        public List<Leitor> Leitores { get; set; }

        [DisplayName("Data do Inicial do Empréstimo")]
        public DateTime DataInicial { get; set; }

        [DisplayName("Data Final do Empréstimo")]
        public DateTime DataFinal { get; set; }

        [DisplayName("Selecione o Livro")]
        public int LivroId { get; set; }
        [ForeignKey("LivroId")]
        public Livro Livro { get; set; }

        [DisplayName("Selecione o Leitor")]
        public int LeitorId { get; set; }
        [ForeignKey("LeitorId")]
        public Leitor Leitor { get; set; }



    }
}
