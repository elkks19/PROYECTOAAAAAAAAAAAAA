﻿using System;
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
    public class AdministradoresController : Controller
    {
        private readonly PruebaFinalContext _context;

        public AdministradoresController(PruebaFinalContext context)
        {
            _context = context;
        }

        // GET: Administradores
        public async Task<IActionResult> Index()
        {
            var pruebaFinalContext = _context.Administradores.Include(a => a.Persona);
            return View(await pruebaFinalContext.ToListAsync());
        }

        // GET: Administradores/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Administradores == null)
            {
                return NotFound();
            }

            var administrador = await _context.Administradores
                .Include(a => a.Persona)
                .FirstOrDefaultAsync(m => m.codAdmin == id);
            if (administrador == null)
            {
                return NotFound();
            }

            return View(administrador);
        }

        // GET: Administradores/Create
        public IActionResult Create()
        {
            ViewData["codPersona"] = new SelectList(_context.Persona, "codPersona", "codPersona");
            return View();
        }

        // POST: Administradores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("codAdmin,codPersona")] Administrador administrador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(administrador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["codPersona"] = new SelectList(_context.Persona, "codPersona", "codPersona", administrador.codPersona);
            return View(administrador);
        }

        // GET: Administradores/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Administradores == null)
            {
                return NotFound();
            }

            var administrador = await _context.Administradores.FindAsync(id);
            if (administrador == null)
            {
                return NotFound();
            }
            ViewData["codPersona"] = new SelectList(_context.Persona, "codPersona", "codPersona", administrador.codPersona);
            return View(administrador);
        }

        // POST: Administradores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("codAdmin,codPersona")] Administrador administrador)
        {
            if (id != administrador.codAdmin)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(administrador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdministradorExists(administrador.codAdmin))
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
            ViewData["codPersona"] = new SelectList(_context.Persona, "codPersona", "codPersona", administrador.codPersona);
            return View(administrador);
        }

        // GET: Administradores/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Administradores == null)
            {
                return NotFound();
            }

            var administrador = await _context.Administradores
                .Include(a => a.Persona)
                .FirstOrDefaultAsync(m => m.codAdmin == id);
            if (administrador == null)
            {
                return NotFound();
            }

            return View(administrador);
        }

        // POST: Administradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Administradores == null)
            {
                return Problem("Entity set 'PruebaFinalContext.Administradores'  is null.");
            }
            var administrador = await _context.Administradores.FindAsync(id);
            if (administrador != null)
            {
                _context.Administradores.Remove(administrador);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdministradorExists(string id)
        {
          return (_context.Administradores?.Any(e => e.codAdmin == id)).GetValueOrDefault();
        }
    }
}
