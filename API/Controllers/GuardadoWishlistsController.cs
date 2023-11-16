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
    public class GuardadoWishlistsController : Controller
    {
        private readonly APIContext _context;

        public GuardadoWishlistsController(APIContext context)
        {
            _context = context;
        }

        // GET: GuardadoWishlists
        public async Task<IActionResult> Index()
        {
            var aPIContext = _context.GuardadoWishlist.Include(g => g.Producto).Include(g => g.Usuario);
            return View(await aPIContext.ToListAsync());
        }

        // GET: GuardadoWishlists/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.GuardadoWishlist == null)
            {
                return NotFound();
            }

            var guardadoWishlist = await _context.GuardadoWishlist
                .Include(g => g.Producto)
                .Include(g => g.Usuario)
                .FirstOrDefaultAsync(m => m.codGuardadoWishlist == id);
            if (guardadoWishlist == null)
            {
                return NotFound();
            }

            return View(guardadoWishlist);
        }

        // GET: GuardadoWishlists/Create
        public IActionResult Create()
        {
            ViewData["codProducto"] = new SelectList(_context.Producto, "codProducto", "codProducto");
            ViewData["codUsuario"] = new SelectList(_context.Usuarios, "codUsuario", "codUsuario");
            return View();
        }

        // POST: GuardadoWishlists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("codGuardadoWishlist,codUsuario,codProducto,fechaGuardado")] GuardadoWishlist guardadoWishlist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guardadoWishlist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["codProducto"] = new SelectList(_context.Producto, "codProducto", "codProducto", guardadoWishlist.codProducto);
            ViewData["codUsuario"] = new SelectList(_context.Usuarios, "codUsuario", "codUsuario", guardadoWishlist.codUsuario);
            return View(guardadoWishlist);
        }

        // GET: GuardadoWishlists/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.GuardadoWishlist == null)
            {
                return NotFound();
            }

            var guardadoWishlist = await _context.GuardadoWishlist.FindAsync(id);
            if (guardadoWishlist == null)
            {
                return NotFound();
            }
            ViewData["codProducto"] = new SelectList(_context.Producto, "codProducto", "codProducto", guardadoWishlist.codProducto);
            ViewData["codUsuario"] = new SelectList(_context.Usuarios, "codUsuario", "codUsuario", guardadoWishlist.codUsuario);
            return View(guardadoWishlist);
        }

        // POST: GuardadoWishlists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("codGuardadoWishlist,codUsuario,codProducto,fechaGuardado")] GuardadoWishlist guardadoWishlist)
        {
            if (id != guardadoWishlist.codGuardadoWishlist)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guardadoWishlist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuardadoWishlistExists(guardadoWishlist.codGuardadoWishlist))
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
            ViewData["codProducto"] = new SelectList(_context.Producto, "codProducto", "codProducto", guardadoWishlist.codProducto);
            ViewData["codUsuario"] = new SelectList(_context.Usuarios, "codUsuario", "codUsuario", guardadoWishlist.codUsuario);
            return View(guardadoWishlist);
        }

        // GET: GuardadoWishlists/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.GuardadoWishlist == null)
            {
                return NotFound();
            }

            var guardadoWishlist = await _context.GuardadoWishlist
                .Include(g => g.Producto)
                .Include(g => g.Usuario)
                .FirstOrDefaultAsync(m => m.codGuardadoWishlist == id);
            if (guardadoWishlist == null)
            {
                return NotFound();
            }

            return View(guardadoWishlist);
        }

        // POST: GuardadoWishlists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.GuardadoWishlist == null)
            {
                return Problem("Entity set 'APIContext.GuardadoWishlist'  is null.");
            }
            var guardadoWishlist = await _context.GuardadoWishlist.FindAsync(id);
            if (guardadoWishlist != null)
            {
                _context.GuardadoWishlist.Remove(guardadoWishlist);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuardadoWishlistExists(string id)
        {
          return (_context.GuardadoWishlist?.Any(e => e.codGuardadoWishlist == id)).GetValueOrDefault();
        }
    }
}
