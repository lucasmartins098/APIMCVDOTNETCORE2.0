using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using crudmysql.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace crudmysql.Controllers
{
    public class Livros2Controller : Controller
    {
        private readonly LivroContexto _context;

        public Livros2Controller(LivroContexto context)
        {
            _context = context;
        }

        // GET: Livros22
        public async Task<IActionResult> Index()
        {
            return View(await _context.Livros2.ToListAsync());
        }

        // GET: Livros2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livros2
                .SingleOrDefaultAsync(m => m.Id == id);
            if (livro == null)
            {
                return NotFound();
            }

            var creds = "teste";

            return Json(livro);
        }

        public async Task<IActionResult> TodosLivros22()
        {
            var livro = _context.Livros2.Last();

            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // GET: Livros22/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Livros22/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Autor,Preco,Lancamento")] Livro livro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(livro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(livro);
        }

        // GET: Livros22/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livros2.SingleOrDefaultAsync(m => m.Id == id);
            if (livro == null)
            {
                return NotFound();
            }
            return View(livro);
        }

        // POST: Livros2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string nome, int idLivro)
        {
            //if (id != livro.Id)
            //{
            //    return NotFound();
            //}

            var livro = await _context.Livros2
                .SingleOrDefaultAsync(m => m.Id == id);

            livro.NomeDolivro2 = nome;
            livro.idLivro = idLivro;

            var livroReferenciado = await _context.Livros
                .SingleOrDefaultAsync(m => m.Id == idLivro);

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(livro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivroExists(livro.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Json(livro);
            }
            return View(livro);
        }

        // GET: Livros22/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livros2
                .SingleOrDefaultAsync(m => m.Id == id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // POST: Livros22/Delete/5
        // [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var livro = await _context.Livros2.SingleOrDefaultAsync(m => m.Id == id);
            _context.Livros2.Remove(livro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LivroExists(int id)
        {
            return _context.Livros2.Any(e => e.Id == id);
        }
    }
}
