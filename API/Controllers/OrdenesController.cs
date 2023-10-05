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
    public class OrdenesController : Controller
    {
        private readonly APIContext _context;

        public OrdenesController(APIContext context)
        {
            _context = context;
        }

        // GET: Ordenes
        public async Task<IActionResult> Index()
        {
            var pruebaFinalContext = _context.Orden.Include(o => o.Empresa).Include(o => o.Usuario);
            return View(await pruebaFinalContext.ToListAsync());
        }

        // GET: Ordenes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Orden == null)
            {
                return NotFound();
            }

            var orden = await _context.Orden
                .Include(o => o.Empresa)
                .Include(o => o.Usuario)
                .FirstOrDefaultAsync(m => m.codOrden == id);
            if (orden == null)
            {
                return NotFound();
            }

            return View(orden);
        }

        // GET: Ordenes/Create
        public IActionResult Create()
        {
            ViewData["codEmpresa"] = new SelectList(_context.Empresa, "codEmpresa", "codEmpresa");
            ViewData["codUsuario"] = new SelectList(_context.Usuarios, "codUsuario", "codUsuario");
            return View();
        }

        // POST: Ordenes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("codOrden,codEmpresa,codUsuario,direccionEntregaOrden,fechaEntregaOrden,fechaPagoOrden,isCancelada,createdAt,lastUpdate")] Orden orden)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orden);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["codEmpresa"] = new SelectList(_context.Empresa, "codEmpresa", "codEmpresa", orden.codEmpresa);
            ViewData["codUsuario"] = new SelectList(_context.Usuarios, "codUsuario", "codUsuario", orden.codUsuario);
            return View(orden);
        }

        // GET: Ordenes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Orden == null)
            {
                return NotFound();
            }

            var orden = await _context.Orden.FindAsync(id);
            if (orden == null)
            {
                return NotFound();
            }
            ViewData["codEmpresa"] = new SelectList(_context.Empresa, "codEmpresa", "codEmpresa", orden.codEmpresa);
            ViewData["codUsuario"] = new SelectList(_context.Usuarios, "codUsuario", "codUsuario", orden.codUsuario);
            return View(orden);
        }

        // POST: Ordenes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("codOrden,codEmpresa,codUsuario,direccionEntregaOrden,fechaEntregaOrden,fechaPagoOrden,isCancelada,createdAt,lastUpdate")] Orden orden)
        {
            if (id != orden.codOrden)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orden);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdenExists(orden.codOrden))
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
            ViewData["codEmpresa"] = new SelectList(_context.Empresa, "codEmpresa", "codEmpresa", orden.codEmpresa);
            ViewData["codUsuario"] = new SelectList(_context.Usuarios, "codUsuario", "codUsuario", orden.codUsuario);
            return View(orden);
        }

        // GET: Ordenes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Orden == null)
            {
                return NotFound();
            }

            var orden = await _context.Orden
                .Include(o => o.Empresa)
                .Include(o => o.Usuario)
                .FirstOrDefaultAsync(m => m.codOrden == id);
            if (orden == null)
            {
                return NotFound();
            }

            return View(orden);
        }

        // POST: Ordenes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Orden == null)
            {
                return Problem("Entity set 'APIContext.Orden'  is null.");
            }
            var orden = await _context.Orden.FindAsync(id);
            if (orden != null)
            {
                _context.Orden.Remove(orden);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdenExists(string id)
        {
          return (_context.Orden?.Any(e => e.codOrden == id)).GetValueOrDefault();
        }
    }
}
