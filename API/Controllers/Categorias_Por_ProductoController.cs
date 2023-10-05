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
    public class Categorias_Por_ProductoController : Controller
    {
        private readonly APIContext _context;

        public Categorias_Por_ProductoController(APIContext context)
        {
            _context = context;
        }

        // GET: Categorias_Por_Producto
        public async Task<IActionResult> Index()
        {
            var pruebaFinalContext = _context.Categorias_Por_Producto.Include(c => c.Categoria).Include(c => c.Producto);
            return View(await pruebaFinalContext.ToListAsync());
        }

        // GET: Categorias_Por_Producto/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Categorias_Por_Producto == null)
            {
                return NotFound();
            }

            var categorias_Por_Producto = await _context.Categorias_Por_Producto
                .Include(c => c.Categoria)
                .Include(c => c.Producto)
                .FirstOrDefaultAsync(m => m.codCategoria == id);
            if (categorias_Por_Producto == null)
            {
                return NotFound();
            }

            return View(categorias_Por_Producto);
        }

        // GET: Categorias_Por_Producto/Create
        public IActionResult Create()
        {
            ViewData["codCategoria"] = new SelectList(_context.Categorias, "codCategoria", "codCategoria");
            ViewData["codProducto"] = new SelectList(_context.Producto, "codProducto", "codProducto");
            return View();
        }

        // POST: Categorias_Por_Producto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("codCategoria,codProducto")] Categorias_Por_Producto categorias_Por_Producto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categorias_Por_Producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["codCategoria"] = new SelectList(_context.Categorias, "codCategoria", "codCategoria", categorias_Por_Producto.codCategoria);
            ViewData["codProducto"] = new SelectList(_context.Producto, "codProducto", "codProducto", categorias_Por_Producto.codProducto);
            return View(categorias_Por_Producto);
        }

        // GET: Categorias_Por_Producto/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Categorias_Por_Producto == null)
            {
                return NotFound();
            }

            var categorias_Por_Producto = await _context.Categorias_Por_Producto.FindAsync(id);
            if (categorias_Por_Producto == null)
            {
                return NotFound();
            }
            ViewData["codCategoria"] = new SelectList(_context.Categorias, "codCategoria", "codCategoria", categorias_Por_Producto.codCategoria);
            ViewData["codProducto"] = new SelectList(_context.Producto, "codProducto", "codProducto", categorias_Por_Producto.codProducto);
            return View(categorias_Por_Producto);
        }

        // POST: Categorias_Por_Producto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("codCategoria,codProducto")] Categorias_Por_Producto categorias_Por_Producto)
        {
            if (id != categorias_Por_Producto.codCategoria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categorias_Por_Producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Categorias_Por_ProductoExists(categorias_Por_Producto.codCategoria))
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
            ViewData["codCategoria"] = new SelectList(_context.Categorias, "codCategoria", "codCategoria", categorias_Por_Producto.codCategoria);
            ViewData["codProducto"] = new SelectList(_context.Producto, "codProducto", "codProducto", categorias_Por_Producto.codProducto);
            return View(categorias_Por_Producto);
        }

        // GET: Categorias_Por_Producto/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Categorias_Por_Producto == null)
            {
                return NotFound();
            }

            var categorias_Por_Producto = await _context.Categorias_Por_Producto
                .Include(c => c.Categoria)
                .Include(c => c.Producto)
                .FirstOrDefaultAsync(m => m.codCategoria == id);
            if (categorias_Por_Producto == null)
            {
                return NotFound();
            }

            return View(categorias_Por_Producto);
        }

        // POST: Categorias_Por_Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Categorias_Por_Producto == null)
            {
                return Problem("Entity set 'APIContext.Categorias_Por_Producto'  is null.");
            }
            var categorias_Por_Producto = await _context.Categorias_Por_Producto.FindAsync(id);
            if (categorias_Por_Producto != null)
            {
                _context.Categorias_Por_Producto.Remove(categorias_Por_Producto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Categorias_Por_ProductoExists(string id)
        {
          return (_context.Categorias_Por_Producto?.Any(e => e.codCategoria == id)).GetValueOrDefault();
        }
    }
}
