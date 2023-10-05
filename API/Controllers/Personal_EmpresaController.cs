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
    public class Personal_EmpresaController : Controller
    {
        private readonly APIContext _context;

        public Personal_EmpresaController(APIContext context)
        {
            _context = context;
        }

        // GET: Personal_Empresa
        public async Task<IActionResult> Index()
        {
            var pruebaFinalContext = _context.Personal_Empresa.Include(p => p.Empresa).Include(p => p.Persona);
            return View(await pruebaFinalContext.ToListAsync());
        }

        // GET: Personal_Empresa/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Personal_Empresa == null)
            {
                return NotFound();
            }

            var personal_Empresa = await _context.Personal_Empresa
                .Include(p => p.Empresa)
                .Include(p => p.Persona)
                .FirstOrDefaultAsync(m => m.codPersonalEmpresa == id);
            if (personal_Empresa == null)
            {
                return NotFound();
            }

            return View(personal_Empresa);
        }

        // GET: Personal_Empresa/Create
        public IActionResult Create()
        {
            ViewData["codEmpresa"] = new SelectList(_context.Empresa, "codEmpresa", "codEmpresa");
            ViewData["codPersona"] = new SelectList(_context.Persona, "codPersona", "codPersona");
            return View();
        }

        // POST: Personal_Empresa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("codPersonalEmpresa,codEmpresa,codPersona")] Personal_Empresa personal_Empresa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personal_Empresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["codEmpresa"] = new SelectList(_context.Empresa, "codEmpresa", "codEmpresa", personal_Empresa.codEmpresa);
            ViewData["codPersona"] = new SelectList(_context.Persona, "codPersona", "codPersona", personal_Empresa.codPersona);
            return View(personal_Empresa);
        }

        // GET: Personal_Empresa/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Personal_Empresa == null)
            {
                return NotFound();
            }

            var personal_Empresa = await _context.Personal_Empresa.FindAsync(id);
            if (personal_Empresa == null)
            {
                return NotFound();
            }
            ViewData["codEmpresa"] = new SelectList(_context.Empresa, "codEmpresa", "codEmpresa", personal_Empresa.codEmpresa);
            ViewData["codPersona"] = new SelectList(_context.Persona, "codPersona", "codPersona", personal_Empresa.codPersona);
            return View(personal_Empresa);
        }

        // POST: Personal_Empresa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("codPersonalEmpresa,codEmpresa,codPersona")] Personal_Empresa personal_Empresa)
        {
            if (id != personal_Empresa.codPersonalEmpresa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personal_Empresa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Personal_EmpresaExists(personal_Empresa.codPersonalEmpresa))
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
            ViewData["codEmpresa"] = new SelectList(_context.Empresa, "codEmpresa", "codEmpresa", personal_Empresa.codEmpresa);
            ViewData["codPersona"] = new SelectList(_context.Persona, "codPersona", "codPersona", personal_Empresa.codPersona);
            return View(personal_Empresa);
        }

        // GET: Personal_Empresa/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Personal_Empresa == null)
            {
                return NotFound();
            }

            var personal_Empresa = await _context.Personal_Empresa
                .Include(p => p.Empresa)
                .Include(p => p.Persona)
                .FirstOrDefaultAsync(m => m.codPersonalEmpresa == id);
            if (personal_Empresa == null)
            {
                return NotFound();
            }

            return View(personal_Empresa);
        }

        // POST: Personal_Empresa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Personal_Empresa == null)
            {
                return Problem("Entity set 'APIContext.Personal_Empresa'  is null.");
            }
            var personal_Empresa = await _context.Personal_Empresa.FindAsync(id);
            if (personal_Empresa != null)
            {
                _context.Personal_Empresa.Remove(personal_Empresa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Personal_EmpresaExists(string id)
        {
          return (_context.Personal_Empresa?.Any(e => e.codPersonalEmpresa == id)).GetValueOrDefault();
        }
    }
}
