using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Models;
using API.Atributos;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class GuardadoCarritoController : Controller
    {
        private readonly APIContext db;
        private readonly UsuariosController usuariosC;

        public GuardadoCarritoController(APIContext context, UsuariosController usuariosController)
        {
            db = context;
            usuariosC = usuariosController;
        }

        [Autorizado]
        [HttpPost]
        [Route("Carrito/Create/{cod}")]
        public async Task<IActionResult> Create([FromRoute]string cod)
        {
            string token = Request.Headers["Authorization"];

            var persona = await usuariosC.getUsuario(token);

            int cantGuardados = await db.GuardadoCarrito.CountAsync() + 1;
            var guardado = new GuardadoCarrito()
            {
                codGuardadoCarrito = "GCAR-" + cantGuardados.ToString("000"),
                Usuario = persona.Usuario,
                codProducto = cod,
            };

            await db.GuardadoCarrito.AddAsync(guardado);
            await db.SaveChangesAsync();

            return Ok("Añadido al carrito");
        }
    }
}
