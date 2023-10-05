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
    public class Detalle_WishlistController : Controller
    {
        private readonly APIContext _context;

        public Detalle_WishlistController(APIContext context)
        {
            _context = context;
        }

        // GET: Detalle_Wishlist
        public async Task<IActionResult> Index()
        {
            var pruebaFinalContext = _context.Detalle_Wishlist.Include(d => d.Producto).Include(d => d.Wishlist);
            return View(await pruebaFinalContext.ToListAsync());
        }

        // GET: Detalle_Wishlist/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Detalle_Wishlist == null)
            {
                return NotFound();
            }

            var detalle_Wishlist = await _context.Detalle_Wishlist
                .Include(d => d.Producto)
                .Include(d => d.Wishlist)
                .FirstOrDefaultAsync(m => m.codWishlist == id);
            if (detalle_Wishlist == null)
            {
                return NotFound();
            }

            return View(detalle_Wishlist);
        }

        // GET: Detalle_Wishlist/Create
        public IActionResult Create()
        {
            ViewData["codProducto"] = new SelectList(_context.Producto, "codProducto", "codProducto");
            ViewData["codWishlist"] = new SelectList(_context.Wishlist, "codWishlist", "codWishlist");
            return View();
        }

        // POST: Detalle_Wishlist/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("codWishlist,codProducto,fechaAnadido,isCarrito")] Detalle_Wishlist detalle_Wishlist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalle_Wishlist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["codProducto"] = new SelectList(_context.Producto, "codProducto", "codProducto", detalle_Wishlist.codProducto);
            ViewData["codWishlist"] = new SelectList(_context.Wishlist, "codWishlist", "codWishlist", detalle_Wishlist.codWishlist);
            return View(detalle_Wishlist);
        }

        // GET: Detalle_Wishlist/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Detalle_Wishlist == null)
            {
                return NotFound();
            }

            var detalle_Wishlist = await _context.Detalle_Wishlist.FindAsync(id);
            if (detalle_Wishlist == null)
            {
                return NotFound();
            }
            ViewData["codProducto"] = new SelectList(_context.Producto, "codProducto", "codProducto", detalle_Wishlist.codProducto);
            ViewData["codWishlist"] = new SelectList(_context.Wishlist, "codWishlist", "codWishlist", detalle_Wishlist.codWishlist);
            return View(detalle_Wishlist);
        }

        // POST: Detalle_Wishlist/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("codWishlist,codProducto,fechaAnadido,isCarrito")] Detalle_Wishlist detalle_Wishlist)
        {
            if (id != detalle_Wishlist.codWishlist)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalle_Wishlist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Detalle_WishlistExists(detalle_Wishlist.codWishlist))
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
            ViewData["codProducto"] = new SelectList(_context.Producto, "codProducto", "codProducto", detalle_Wishlist.codProducto);
            ViewData["codWishlist"] = new SelectList(_context.Wishlist, "codWishlist", "codWishlist", detalle_Wishlist.codWishlist);
            return View(detalle_Wishlist);
        }

        // GET: Detalle_Wishlist/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Detalle_Wishlist == null)
            {
                return NotFound();
            }

            var detalle_Wishlist = await _context.Detalle_Wishlist
                .Include(d => d.Producto)
                .Include(d => d.Wishlist)
                .FirstOrDefaultAsync(m => m.codWishlist == id);
            if (detalle_Wishlist == null)
            {
                return NotFound();
            }

            return View(detalle_Wishlist);
        }

        // POST: Detalle_Wishlist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Detalle_Wishlist == null)
            {
                return Problem("Entity set 'APIContext.Detalle_Wishlist'  is null.");
            }
            var detalle_Wishlist = await _context.Detalle_Wishlist.FindAsync(id);
            if (detalle_Wishlist != null)
            {
                _context.Detalle_Wishlist.Remove(detalle_Wishlist);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Detalle_WishlistExists(string id)
        {
          return (_context.Detalle_Wishlist?.Any(e => e.codWishlist == id)).GetValueOrDefault();
        }
    }
}
