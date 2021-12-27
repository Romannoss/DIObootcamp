using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using testeWebApp.Models;

namespace testeWebApp.Controllers
{
    public class produtosController : Controller
    {
        private readonly context _context;

        public produtosController(context context)
        {
            _context = context;
        }

        // GET: produtos
        public async Task<IActionResult> Index()
        {
            var context = _context.produtos.Include(p => p.categoria);
            return View(await context.ToListAsync());
        }

        // GET: produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.produtos
                .Include(p => p.categoria)
                .FirstOrDefaultAsync(m => m.id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: produtos/Create
        public IActionResult Create()
        {
            ViewData["categoriaid"] = new SelectList(_context.categorias, "id", "descricao");
            return View();
        }

        // POST: produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,descricao,quantidade,categoriaid")] produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["categoriaid"] = new SelectList(_context.categorias, "id", "descricao", produto.categoriaid);
            return View(produto);
        }

        // GET: produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            ViewData["categoriaid"] = new SelectList(_context.categorias, "id", "descricao", produto.categoriaid);
            return View(produto);
        }

        // POST: produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,descricao,quantidade,categoriaid")] produto produto)
        {
            if (id != produto.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!produtoExists(produto.id))
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
            ViewData["categoriaid"] = new SelectList(_context.categorias, "id", "descricao", produto.categoriaid);
            return View(produto);
        }

        // GET: produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.produtos
                .Include(p => p.categoria)
                .FirstOrDefaultAsync(m => m.id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.produtos.FindAsync(id);
            _context.produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool produtoExists(int id)
        {
            return _context.produtos.Any(e => e.id == id);
        }
    }
}
