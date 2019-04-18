using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace crudBiblioteca.Models
{
    public class Leitor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [DisplayName("Endereço")]
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        
    }
}
