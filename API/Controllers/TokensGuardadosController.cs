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
    public class TokensGuardadosController : Controller
    {
        private readonly APIContext _context;

        public TokensGuardadosController(APIContext context)
        {
            _context = context;
        }

        // GET: TokensGuardados
        public async Task<IActionResult> Index()
        {
              return _context.TokenGuardado != null ? 
                          View(await _context.TokenGuardado.ToListAsync()) :
                          Problem("Entity set 'APIContext.TokenGuardado'  is null.");
        }

        // GET: TokensGuardados/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.TokenGuardado == null)
            {
                return NotFound();
            }

            var tokenGuardado = await _context.TokenGuardado
                .FirstOrDefaultAsync(m => m.codToken == id);
            if (tokenGuardado == null)
            {
                return NotFound();
            }

            return View(tokenGuardado);
        }

        // GET: TokensGuardados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TokensGuardados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("codToken,codPersona,fechaCreacionToken")] TokenGuardado tokenGuardado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tokenGuardado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tokenGuardado);
        }

        // GET: TokensGuardados/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.TokenGuardado == null)
            {
                return NotFound();
            }

            var tokenGuardado = await _context.TokenGuardado.FindAsync(id);
            if (tokenGuardado == null)
            {
                return NotFound();
            }
            return View(tokenGuardado);
        }

        // POST: TokensGuardados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("codToken,codPersona,fechaCreacionToken")] TokenGuardado tokenGuardado)
        {
            if (id != tokenGuardado.codToken)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tokenGuardado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TokenGuardadoExists(tokenGuardado.codToken))
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
            return View(tokenGuardado);
        }

        // GET: TokensGuardados/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.TokenGuardado == null)
            {
                return NotFound();
            }

            var tokenGuardado = await _context.TokenGuardado
                .FirstOrDefaultAsync(m => m.codToken == id);
            if (tokenGuardado == null)
            {
                return NotFound();
            }

            return View(tokenGuardado);
        }

        // POST: TokensGuardados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.TokenGuardado == null)
            {
                return Problem("Entity set 'APIContext.TokenGuardado'  is null.");
            }
            var tokenGuardado = await _context.TokenGuardado.FindAsync(id);
            if (tokenGuardado != null)
            {
                _context.TokenGuardado.Remove(tokenGuardado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TokenGuardadoExists(string id)
        {
          return (_context.TokenGuardado?.Any(e => e.codToken == id)).GetValueOrDefault();
        }
    }
}
