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
    public class Reclamos_EmpresaController : Controller
    {
        private readonly APIContext _context;

        public Reclamos_EmpresaController(APIContext context)
        {
            _context = context;
        }

        // GET: Reclamos_Empresa
        public async Task<IActionResult> Index()
        {
            var pruebaFinalContext = _context.Reclamos_Empresa.Include(r => r.Administrador).Include(r => r.Producto).Include(r => r.Usuario);
            return View(await pruebaFinalContext.ToListAsync());
        }

        // GET: Reclamos_Empresa/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Reclamos_Empresa == null)
            {
                return NotFound();
            }

            var reclamos_Empresa = await _context.Reclamos_Empresa
                .Include(r => r.Administrador)
                .Include(r => r.Producto)
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(m => m.codReclamo == id);
            if (reclamos_Empresa == null)
            {
                return NotFound();
            }

            return View(reclamos_Empresa);
        }

        // GET: Reclamos_Empresa/Create
        public IActionResult Create()
        {
            ViewData["codAdmin"] = new SelectList(_context.Administradores, "codAdmin", "codAdmin");
            ViewData["codProducto"] = new SelectList(_context.Producto, "codProducto", "codProducto");
            ViewData["codUsuario"] = new SelectList(_context.Usuarios, "codUsuario", "codUsuario");
            return View();
        }

        // POST: Reclamos_Empresa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("codReclamo,codProducto,codUsuario,contenidoReclamo,respuestaReclamo,codAdmin,isRevisado,fechaCreacionReclamo,fechaRevisionReclamo")] Reclamos_Empresa reclamos_Empresa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reclamos_Empresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["codAdmin"] = new SelectList(_context.Administradores, "codAdmin", "codAdmin", reclamos_Empresa.codAdmin);
            ViewData["codProducto"] = new SelectList(_context.Producto, "codProducto", "codProducto", reclamos_Empresa.codProducto);
            ViewData["codUsuario"] = new SelectList(_context.Usuarios, "codUsuario", "codUsuario", reclamos_Empresa.codUsuario);
            return View(reclamos_Empresa);
        }

        // GET: Reclamos_Empresa/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Reclamos_Empresa == null)
            {
                return NotFound();
            }

            var reclamos_Empresa = await _context.Reclamos_Empresa.FindAsync(id);
            if (reclamos_Empresa == null)
            {
                return NotFound();
            }
            ViewData["codAdmin"] = new SelectList(_context.Administradores, "codAdmin", "codAdmin", reclamos_Empresa.codAdmin);
            ViewData["codProducto"] = new SelectList(_context.Producto, "codProducto", "codProducto", reclamos_Empresa.codProducto);
            ViewData["codUsuario"] = new SelectList(_context.Usuarios, "codUsuario", "codUsuario", reclamos_Empresa.codUsuario);
            return View(reclamos_Empresa);
        }

        // POST: Reclamos_Empresa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("codReclamo,codProducto,codUsuario,contenidoReclamo,respuestaReclamo,codAdmin,isRevisado,fechaCreacionReclamo,fechaRevisionReclamo")] Reclamos_Empresa reclamos_Empresa)
        {
            if (id != reclamos_Empresa.codReclamo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reclamos_Empresa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Reclamos_EmpresaExists(reclamos_Empresa.codReclamo))
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
            ViewData["codAdmin"] = new SelectList(_context.Administradores, "codAdmin", "codAdmin", reclamos_Empresa.codAdmin);
            ViewData["codProducto"] = new SelectList(_context.Producto, "codProducto", "codProducto", reclamos_Empresa.codProducto);
            ViewData["codUsuario"] = new SelectList(_context.Usuarios, "codUsuario", "codUsuario", reclamos_Empresa.codUsuario);
            return View(reclamos_Empresa);
        }

        // GET: Reclamos_Empresa/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Reclamos_Empresa == null)
            {
                return NotFound();
            }

            var reclamos_Empresa = await _context.Reclamos_Empresa
                .Include(r => r.Administrador)
                .Include(r => r.Producto)
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(m => m.codReclamo == id);
            if (reclamos_Empresa == null)
            {
                return NotFound();
            }

            return View(reclamos_Empresa);
        }

        // POST: Reclamos_Empresa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Reclamos_Empresa == null)
            {
                return Problem("Entity set 'APIContext.Reclamos_Empresa'  is null.");
            }
            var reclamos_Empresa = await _context.Reclamos_Empresa.FindAsync(id);
            if (reclamos_Empresa != null)
            {
                _context.Reclamos_Empresa.Remove(reclamos_Empresa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Reclamos_EmpresaExists(string id)
        {
          return (_context.Reclamos_Empresa?.Any(e => e.codReclamo == id)).GetValueOrDefault();
        }
    }
}
