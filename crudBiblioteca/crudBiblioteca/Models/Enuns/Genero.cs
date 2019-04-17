using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace crudBiblioteca.Models.Enuns
{
    public enum Genero
    {
        Romance,
        Aventura,
        Biografia,
        [Display(Name = "Didático")]
        Didatico,
        [Display(Name = "Ficção")]
        Ficcao,
        [Display(Name = "Científico")]
        Cientifico,
        Poesia,
        [Display(Name = "Cronicas")]
        Cronicas,
        Infantil,
        Contos
    }
}
