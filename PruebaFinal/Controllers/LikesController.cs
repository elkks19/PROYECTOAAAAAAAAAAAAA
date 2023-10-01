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
    public class LikesController : Controller
    {
        private readonly PruebaFinalContext _context;

        public LikesController(PruebaFinalContext context)
        {
            _context = context;
        }

        // GET: Likes
        public async Task<IActionResult> Index()
        {
            var pruebaFinalContext = _context.Like.Include(l => l.Producto).Include(l => l.Usuario);
            return View(await pruebaFinalContext.ToListAsync());
        }

        // GET: Likes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Like == null)
            {
                return NotFound();
            }

            var like = await _context.Like
                .Include(l => l.Producto)
                .Include(l => l.Usuario)
                .FirstOrDefaultAsync(m => m.codLike == id);
            if (like == null)
            {
                return NotFound();
            }

            return View(like);
        }

        // GET: Likes/Create
        public IActionResult Create()
        {
            ViewData["codProducto"] = new SelectList(_context.Producto, "codProducto", "codProducto");
            ViewData["codUsuario"] = new SelectList(_context.Usuarios, "codUsuario", "codUsuario");
            return View();
        }

        // POST: Likes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("codLike,codUsuario,codProducto,fechaLike")] Like like)
        {
            if (ModelState.IsValid)
            {
                _context.Add(like);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["codProducto"] = new SelectList(_context.Producto, "codProducto", "codProducto", like.codProducto);
            ViewData["codUsuario"] = new SelectList(_context.Usuarios, "codUsuario", "codUsuario", like.codUsuario);
            return View(like);
        }

        // GET: Likes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Like == null)
            {
                return NotFound();
            }

            var like = await _context.Like.FindAsync(id);
            if (like == null)
            {
                return NotFound();
            }
            ViewData["codProducto"] = new SelectList(_context.Producto, "codProducto", "codProducto", like.codProducto);
            ViewData["codUsuario"] = new SelectList(_context.Usuarios, "codUsuario", "codUsuario", like.codUsuario);
            return View(like);
        }

        // POST: Likes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("codLike,codUsuario,codProducto,fechaLike")] Like like)
        {
            if (id != like.codLike)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(like);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LikeExists(like.codLike))
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
            ViewData["codProducto"] = new SelectList(_context.Producto, "codProducto", "codProducto", like.codProducto);
            ViewData["codUsuario"] = new SelectList(_context.Usuarios, "codUsuario", "codUsuario", like.codUsuario);
            return View(like);
        }

        // GET: Likes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Like == null)
            {
                return NotFound();
            }

            var like = await _context.Like
                .Include(l => l.Producto)
                .Include(l => l.Usuario)
                .FirstOrDefaultAsync(m => m.codLike == id);
            if (like == null)
            {
                return NotFound();
            }

            return View(like);
        }

        // POST: Likes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Like == null)
            {
                return Problem("Entity set 'PruebaFinalContext.Like'  is null.");
            }
            var like = await _context.Like.FindAsync(id);
            if (like != null)
            {
                _context.Like.Remove(like);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LikeExists(string id)
        {
          return (_context.Like?.Any(e => e.codLike == id)).GetValueOrDefault();
        }
    }
}
