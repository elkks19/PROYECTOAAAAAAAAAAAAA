using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;

namespace API.Controllers
{
    public class ComentariosController : Controller
    {
        private readonly APIContext _context;

        public ComentariosController(APIContext context)
        {
            _context = context;
        }

        // GET: Comentarios
        public async Task<IActionResult> Index()
        {
            var pruebaFinalContext = _context.Comentarios.Include(c => c.Persona).Include(c => c.Producto);
            return View(await pruebaFinalContext.ToListAsync());
        }

        // GET: Comentarios/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Comentarios == null)
            {
                return NotFound();
            }

            var comentario = await _context.Comentarios
                .Include(c => c.Persona)
                .Include(c => c.Producto)
                .FirstOrDefaultAsync(m => m.codComentario == id);
            if (comentario == null)
            {
                return NotFound();
            }

            return View(comentario);
        }

        // GET: Comentarios/Create
        public IActionResult Create()
        {
            ViewData["codPersona"] = new SelectList(_context.Persona, "codPersona", "codPersona");
            ViewData["codProducto"] = new SelectList(_context.Producto, "codProducto", "codProducto");
            return View();
        }

        // POST: Comentarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("codComentario,codPersona,codProducto,contenidoComentario,createdAt,lastUpdate")] Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comentario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["codPersona"] = new SelectList(_context.Persona, "codPersona", "codPersona", comentario.codPersona);
            ViewData["codProducto"] = new SelectList(_context.Producto, "codProducto", "codProducto", comentario.codProducto);
            return View(comentario);
        }

        // GET: Comentarios/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Comentarios == null)
            {
                return NotFound();
            }

            var comentario = await _context.Comentarios.FindAsync(id);
            if (comentario == null)
            {
                return NotFound();
            }
            ViewData["codPersona"] = new SelectList(_context.Persona, "codPersona", "codPersona", comentario.codPersona);
            ViewData["codProducto"] = new SelectList(_context.Producto, "codProducto", "codProducto", comentario.codProducto);
            return View(comentario);
        }

        // POST: Comentarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("codComentario,codPersona,codProducto,contenidoComentario,createdAt,lastUpdate")] Comentario comentario)
        {
            if (id != comentario.codComentario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comentario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComentarioExists(comentario.codComentario))
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
            ViewData["codPersona"] = new SelectList(_context.Persona, "codPersona", "codPersona", comentario.codPersona);
            ViewData["codProducto"] = new SelectList(_context.Producto, "codProducto", "codProducto", comentario.codProducto);
            return View(comentario);
        }

        // GET: Comentarios/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Comentarios == null)
            {
                return NotFound();
            }

            var comentario = await _context.Comentarios
                .Include(c => c.Persona)
                .Include(c => c.Producto)
                .FirstOrDefaultAsync(m => m.codComentario == id);
            if (comentario == null)
            {
                return NotFound();
            }

            return View(comentario);
        }

        // POST: Comentarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Comentarios == null)
            {
                return Problem("Entity set 'APIContext.Comentarios'  is null.");
            }
            var comentario = await _context.Comentarios.FindAsync(id);
            if (comentario != null)
            {
                _context.Comentarios.Remove(comentario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComentarioExists(string id)
        {
          return (_context.Comentarios?.Any(e => e.codComentario == id)).GetValueOrDefault();
        }
    }
}
