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
        private readonly APIContext db;

        public GuardadoWishlistsController(APIContext context)
        {
            db = context;
        }

        protected internal async Task<GuardadoWishlist> Create(Producto prod, Usuario usu)
        {
            var cantG = await db.GuardadoWishlist.CountAsync() + 1;
            var a = new GuardadoWishlist()
            {
                codGuardadoWishlist = "GWI-" + cantG.ToString("000"),
                Producto = prod,
                Usuario = usu,
                fechaGuardado = DateTime.Now
            };

            await db.GuardadoWishlist.AddAsync(a);
            await db.SaveChangesAsync();
            return a;
        }
    }
}
