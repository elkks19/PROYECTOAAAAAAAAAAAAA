using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PruebaFinal.Data;
using PruebaFinal.Models;

namespace PruebaFinal.Controllers
{
    public class Detalle_OrdenController : Controller
    {
        private readonly PruebaFinalContext _context;

        public Detalle_OrdenController(PruebaFinalContext context)
        {
            _context = context;
        }

        // GET: Detalle_Orden
        public async Task<IActionResult> Index()
        {
            var pruebaFinalContext = _context.Detalle_Orden.Include(d => d.Orden).Include(d => d.Producto);
            return View(await pruebaFinalContext.ToListAsync());
        }

        // GET: Detalle_Orden/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Detalle_Orden == null)
            {
                return NotFound();
            }

            var detalle_Orden = await _context.Detalle_Orden
                .Include(d => d.Orden)
                .Include(d => d.Producto)
                .FirstOrDefaultAsync(m => m.codOrden == id);
            if (detalle_Orden == null)
            {
                return NotFound();
            }

            return View(detalle_Orden);
        }

        // GET: Detalle_Orden/Create
        public IActionResult Create()
        {
            ViewData["codOrden"] = new SelectList(_context.Orden, "codOrden", "codOrden");
            ViewData["codProducto"] = new SelectList(_context.Producto, "codProducto", "codProducto");
            return View();
        }

        // POST: Detalle_Orden/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("codOrden,codProducto,cantidadProducto,precioTotal")] Detalle_Orden detalle_Orden)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalle_Orden);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["codOrden"] = new SelectList(_context.Orden, "codOrden", "codOrden", detalle_Orden.codOrden);
            ViewData["codProducto"] = new SelectList(_context.Producto, "codProducto", "codProducto", detalle_Orden.codProducto);
            return View(detalle_Orden);
        }

        // GET: Detalle_Orden/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Detalle_Orden == null)
            {
                return NotFound();
            }

            var detalle_Orden = await _context.Detalle_Orden.FindAsync(id);
            if (detalle_Orden == null)
            {
                return NotFound();
            }
            ViewData["codOrden"] = new SelectList(_context.Orden, "codOrden", "codOrden", detalle_Orden.codOrden);
            ViewData["codProducto"] = new SelectList(_context.Producto, "codProducto", "codProducto", detalle_Orden.codProducto);
            return View(detalle_Orden);
        }

        // POST: Detalle_Orden/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("codOrden,codProducto,cantidadProducto,precioTotal")] Detalle_Orden detalle_Orden)
        {
            if (id != detalle_Orden.codOrden)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalle_Orden);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Detalle_OrdenExists(detalle_Orden.codOrden))
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
            ViewData["codOrden"] = new SelectList(_context.Orden, "codOrden", "codOrden", detalle_Orden.codOrden);
            ViewData["codProducto"] = new SelectList(_context.Producto, "codProducto", "codProducto", detalle_Orden.codProducto);
            return View(detalle_Orden);
        }

        // GET: Detalle_Orden/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Detalle_Orden == null)
            {
                return NotFound();
            }

            var detalle_Orden = await _context.Detalle_Orden
                .Include(d => d.Orden)
                .Include(d => d.Producto)
                .FirstOrDefaultAsync(m => m.codOrden == id);
            if (detalle_Orden == null)
            {
                return NotFound();
            }

            return View(detalle_Orden);
        }

        // POST: Detalle_Orden/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Detalle_Orden == null)
            {
                return Problem("Entity set 'PruebaFinalContext.Detalle_Orden'  is null.");
            }
            var detalle_Orden = await _context.Detalle_Orden.FindAsync(id);
            if (detalle_Orden != null)
            {
                _context.Detalle_Orden.Remove(detalle_Orden);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Detalle_OrdenExists(string id)
        {
          return (_context.Detalle_Orden?.Any(e => e.codOrden == id)).GetValueOrDefault();
        }
    }
}
