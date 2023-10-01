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
    public class Lista_Espera_EmpresaController : Controller
    {
        private readonly PruebaFinalContext _context;

        public Lista_Espera_EmpresaController(PruebaFinalContext context)
        {
            _context = context;
        }

        // GET: Lista_Espera_Empresa
        public async Task<IActionResult> Index()
        {
            var pruebaFinalContext = _context.Lista_Espera_Empresa.Include(l => l.Administrador).Include(l => l.Empresa);
            return View(await pruebaFinalContext.ToListAsync());
        }

        // GET: Lista_Espera_Empresa/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Lista_Espera_Empresa == null)
            {
                return NotFound();
            }

            var lista_Espera_Empresa = await _context.Lista_Espera_Empresa
                .Include(l => l.Administrador)
                .Include(l => l.Empresa)
                .FirstOrDefaultAsync(m => m.codEmpresa == id);
            if (lista_Espera_Empresa == null)
            {
                return NotFound();
            }

            return View(lista_Espera_Empresa);
        }

        // GET: Lista_Espera_Empresa/Create
        public IActionResult Create()
        {
            ViewData["codAdmin"] = new SelectList(_context.Administradores, "codAdmin", "codAdmin");
            ViewData["codEmpresa"] = new SelectList(_context.Empresa, "codEmpresa", "codEmpresa");
            return View();
        }

        // POST: Lista_Espera_Empresa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("isRevisado,fechaRevision,fechaSolicitudRevision,codEmpresa,codAdmin")] Lista_Espera_Empresa lista_Espera_Empresa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lista_Espera_Empresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["codAdmin"] = new SelectList(_context.Administradores, "codAdmin", "codAdmin", lista_Espera_Empresa.codAdmin);
            ViewData["codEmpresa"] = new SelectList(_context.Empresa, "codEmpresa", "codEmpresa", lista_Espera_Empresa.codEmpresa);
            return View(lista_Espera_Empresa);
        }

        // GET: Lista_Espera_Empresa/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Lista_Espera_Empresa == null)
            {
                return NotFound();
            }

            var lista_Espera_Empresa = await _context.Lista_Espera_Empresa.FindAsync(id);
            if (lista_Espera_Empresa == null)
            {
                return NotFound();
            }
            ViewData["codAdmin"] = new SelectList(_context.Administradores, "codAdmin", "codAdmin", lista_Espera_Empresa.codAdmin);
            ViewData["codEmpresa"] = new SelectList(_context.Empresa, "codEmpresa", "codEmpresa", lista_Espera_Empresa.codEmpresa);
            return View(lista_Espera_Empresa);
        }

        // POST: Lista_Espera_Empresa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("isRevisado,fechaRevision,fechaSolicitudRevision,codEmpresa,codAdmin")] Lista_Espera_Empresa lista_Espera_Empresa)
        {
            if (id != lista_Espera_Empresa.codEmpresa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lista_Espera_Empresa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Lista_Espera_EmpresaExists(lista_Espera_Empresa.codEmpresa))
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
            ViewData["codAdmin"] = new SelectList(_context.Administradores, "codAdmin", "codAdmin", lista_Espera_Empresa.codAdmin);
            ViewData["codEmpresa"] = new SelectList(_context.Empresa, "codEmpresa", "codEmpresa", lista_Espera_Empresa.codEmpresa);
            return View(lista_Espera_Empresa);
        }

        // GET: Lista_Espera_Empresa/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Lista_Espera_Empresa == null)
            {
                return NotFound();
            }

            var lista_Espera_Empresa = await _context.Lista_Espera_Empresa
                .Include(l => l.Administrador)
                .Include(l => l.Empresa)
                .FirstOrDefaultAsync(m => m.codEmpresa == id);
            if (lista_Espera_Empresa == null)
            {
                return NotFound();
            }

            return View(lista_Espera_Empresa);
        }

        // POST: Lista_Espera_Empresa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Lista_Espera_Empresa == null)
            {
                return Problem("Entity set 'PruebaFinalContext.Lista_Espera_Empresa'  is null.");
            }
            var lista_Espera_Empresa = await _context.Lista_Espera_Empresa.FindAsync(id);
            if (lista_Espera_Empresa != null)
            {
                _context.Lista_Espera_Empresa.Remove(lista_Espera_Empresa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Lista_Espera_EmpresaExists(string id)
        {
          return (_context.Lista_Espera_Empresa?.Any(e => e.codEmpresa == id)).GetValueOrDefault();
        }
    }
}
