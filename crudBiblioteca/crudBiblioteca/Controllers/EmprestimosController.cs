using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using crudBiblioteca.Data;
using crudBiblioteca.Models;
using crudBiblioteca.Models.Enuns;

namespace crudBiblioteca.Controllers
{
    public class EmprestimosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private Status status;

        public EmprestimosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Emprestimos
        public async Task<IActionResult> Index()
        {

            var leitores = _context.Emprestimos.Include(e => e.Leitor).Include(f => f.Livro);
            ViewData["Leitores"] = new SelectList(leitores, "Id", "Nome");
            return View(await leitores.ToListAsync());
        }

        // GET: Emprestimos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emprestimo = await _context.Emprestimos
                .Include(e => e.Leitor)
                .Include(e => e.Livro)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        // GET: Emprestimos/Create
        public IActionResult Create()
        {
            ViewData["LeitorId"] = new SelectList(_context.Leitores, "Id", "Nome");
            ViewData["LivroId"] = new SelectList(_context.Livros.Where(x => x.Status == Status.Disponivel), "Id", "Nome");
            return View();
        }

        // POST: Emprestimos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataInicial,DataFinal,Status,LivroId,LeitorId")] Emprestimo emprestimo)
        {
            if (ModelState.IsValid)
            {
                Livro decrementaquantidadelivros = _context.Livros.Find(emprestimo.LivroId);
                decrementaquantidadelivros.Emprestar(emprestimo.LivroId);
                await _context.SaveChangesAsync();

                _context.Add(emprestimo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           
            ViewData["LeitorId"] = new SelectList(_context.Leitores, "Id", "Nome", emprestimo.LeitorId);
            ViewData["LivroId"] = new SelectList(_context.Livros, "Id", "Nome", emprestimo.LivroId);
           
            return View(emprestimo);
        }
       
        // GET: Emprestimos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emprestimo = await _context.Emprestimos.FindAsync(id);
            if (emprestimo == null)
            {
                return NotFound();
            }
            ViewData["LeitorId"] = new SelectList(_context.Leitores, "Id", "Nome", emprestimo.LeitorId);
            ViewData["LivroId"] = new SelectList(_context.Livros, "Id", "Nome", emprestimo.LivroId);
            return View(emprestimo);
        }

        // POST: Emprestimos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataInicial,DataFinal,Status,LivroId,LeitorId")] Emprestimo emprestimo)
        {
            if (id != emprestimo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emprestimo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmprestimoExists(emprestimo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["LeitorId"] = new SelectList(_context.Leitores, "Id", "Nome", emprestimo.LeitorId);
            ViewData["LivroId"] = new SelectList(_context.Livros, "Id", "Nome", emprestimo.LivroId);
            return View(emprestimo);
        }

        // GET: Emprestimos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emprestimo = await _context.Emprestimos
                .Include(e => e.Leitor)
                .Include(e => e.Livro)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        // POST: Emprestimos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emprestimo = await _context.Emprestimos.FindAsync(id);
            _context.Emprestimos.Remove(emprestimo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmprestimoExists(int id)
        {
            return _context.Emprestimos.Any(e => e.Id == id);
        }

    }
}
