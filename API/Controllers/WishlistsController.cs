using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;

namespace API.Controllers
{
    public class WishlistsController : Controller
    {
        private readonly APIContext db;
        private readonly UsuariosController usuariosC;
        private readonly GuardadoWishlistsController guardadoWC;

        public WishlistsController(APIContext context, UsuariosController usuariosController, GuardadoWishlistsController guardadoWC)
        {
            db = context;
            usuariosC = usuariosController;
            this.guardadoWC = guardadoWC;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var token = Request.Headers["Authorization"];

            var persona = await usuariosC.getUsuario(token);

            if (persona == null)
            {
                return BadRequest("No se encontro la persona");
            }

            await db.Entry(persona).Reference(x => x.Usuario).LoadAsync();

            var wish = await db.Wishlist.Where(x => x.codUsuario.Equals(persona.Usuario.codUsuario)).ToListAsync();

            return Ok(wish);
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromRoute]string cod)
        {
            var token = Request.Headers["Authorization"];

            var persona = await usuariosC.getUsuario(token);

            if (persona == null)
            {
                return BadRequest("No se encontro la persona");
            }

            await db.Entry(persona).Reference(x => x.Usuario).LoadAsync();
            var usuario = persona.Usuario;

            var producto = await db.Producto.FirstOrDefaultAsync(x => x.codProducto.Equals(cod));
            if (producto == null)
            {
                return BadRequest("No se encontro el producto");
            }

            await db.Entry(usuario).Collection(x => x.Wishlist).LoadAsync();
            var wish = usuario.Wishlist;

            wish.Add(new Wishlist()
            {
                Producto = producto,
                Usuario = usuario,
                fechaAnadido = DateTime.Now
            });

            var guardado = await guardadoWC.Create(producto, usuario);
            if (guardado == null)
            {
                return BadRequest("No se pudo guardar");
            }

            await db.SaveChangesAsync();

            return Ok("Se agrego correctemante a la wishlist");
        }
    }
}
