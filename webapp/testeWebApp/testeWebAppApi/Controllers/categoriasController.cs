using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testeWebApp.Models;

namespace testeWebAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class categoriasController : ControllerBase
    {
        private readonly context _context;

        public categoriasController(context context)
        {
            _context = context;
        }

        // GET: api/categorias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<categoria>>> Getcategorias()
        {
            return await _context.categorias.ToListAsync();
        }

        // GET: api/categorias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<categoria>> Getcategoria(int id)
        {
            var categoria = await _context.categorias.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return categoria;
        }

        // PUT: api/categorias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putcategoria(int id, categoria categoria)
        {
            if (id != categoria.id)
            {
                return BadRequest();
            }

            _context.Entry(categoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!categoriaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/categorias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<categoria>> Postcategoria(categoria categoria)
        {
            _context.categorias.Add(categoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getcategoria", new { id = categoria.id }, categoria);
        }

        // DELETE: api/categorias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletecategoria(int id)
        {
            var categoria = await _context.categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _context.categorias.Remove(categoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool categoriaExists(int id)
        {
            return _context.categorias.Any(e => e.id == id);
        }
    }
}
