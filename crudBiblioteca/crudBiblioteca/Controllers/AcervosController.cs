using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using crudBiblioteca.Data;
using crudBiblioteca.Models;

namespace crudBiblioteca.Controllers
{
    public class AcervosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AcervosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Acervos
        public IActionResult Index()
        {
            var Acervo = _context.Acervos.Include(x => x.Livros).FirstOrDefault();
            return View(Acervo);
        }
    }
}

