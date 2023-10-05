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
    public class WishlistsController : Controller
    {
        private readonly APIContext _context;

        public WishlistsController(APIContext context)
        {
            _context = context;
        }

        // GET: Wishlists
        public async Task<IActionResult> Index()
        {
            var pruebaFinalContext = _context.Wishlist.Include(w => w.Usuario);
            return View(await pruebaFinalContext.ToListAsync());
        }

        // GET: Wishlists/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Wishlist == null)
            {
                return NotFound();
            }

            var wishlist = await _context.Wishlist
                .Include(w => w.Usuario)
                .FirstOrDefaultAsync(m => m.codWishlist == id);
            if (wishlist == null)
            {
                return NotFound();
            }

            return View(wishlist);
        }

        // GET: Wishlists/Create
        public IActionResult Create()
        {
            ViewData["codUsuario"] = new SelectList(_context.Usuarios, "codUsuario", "codUsuario");
            return View();
        }

        // POST: Wishlists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("codWishlist,codUsuario")] Wishlist wishlist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wishlist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["codUsuario"] = new SelectList(_context.Usuarios, "codUsuario", "codUsuario", wishlist.codUsuario);
            return View(wishlist);
        }

        // GET: Wishlists/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Wishlist == null)
            {
                return NotFound();
            }

            var wishlist = await _context.Wishlist.FindAsync(id);
            if (wishlist == null)
            {
                return NotFound();
            }
            ViewData["codUsuario"] = new SelectList(_context.Usuarios, "codUsuario", "codUsuario", wishlist.codUsuario);
            return View(wishlist);
        }

        // POST: Wishlists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("codWishlist,codUsuario")] Wishlist wishlist)
        {
            if (id != wishlist.codWishlist)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wishlist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WishlistExists(wishlist.codWishlist))
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
            ViewData["codUsuario"] = new SelectList(_context.Usuarios, "codUsuario", "codUsuario", wishlist.codUsuario);
            return View(wishlist);
        }

        // GET: Wishlists/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Wishlist == null)
            {
                return NotFound();
            }

            var wishlist = await _context.Wishlist
                .Include(w => w.Usuario)
                .FirstOrDefaultAsync(m => m.codWishlist == id);
            if (wishlist == null)
            {
                return NotFound();
            }

            return View(wishlist);
        }

        // POST: Wishlists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Wishlist == null)
            {
                return Problem("Entity set 'APIContext.Wishlist'  is null.");
            }
            var wishlist = await _context.Wishlist.FindAsync(id);
            if (wishlist != null)
            {
                _context.Wishlist.Remove(wishlist);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WishlistExists(string id)
        {
          return (_context.Wishlist?.Any(e => e.codWishlist == id)).GetValueOrDefault();
        }
    }
}
