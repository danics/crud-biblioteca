using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace crudBiblioteca.Models.Enuns
{
    public enum Status
    {
        [Display(Name = "Disponível")]
        Disponivel,
        [Display(Name = "Indisponível")]
        Indisponivel
    }
}
