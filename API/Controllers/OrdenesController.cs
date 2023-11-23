using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Models;
using API.Atributos;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class OrdenesController : Controller
    {
        private readonly APIContext db;
        private readonly DetalleOrdenController detalleOrdenC;
        private readonly UsuariosController usuariosC;

        public OrdenesController(APIContext context, DetalleOrdenController detalleOrdenController, UsuariosController usuariosController)
        {
            db = context;
            detalleOrdenC = detalleOrdenController;
            usuariosC = usuariosController;
        }


        public class prueba
        {
            public string codProducto { get; set; }
            public int cantidad { get; set; }
        }
        public class OrdenRequest
        {
            public prueba[] a { get; set;} 
        }

        [HttpPost]
        [Autorizado(rol2 = "administrador")]
        public async Task<IActionResult> Create([FromBody]OrdenRequest request)
        {
            var token = Request.Headers["Authorization"];
            var persona = await usuariosC.getUsuario(token);
            if (persona == null)
            {
                return BadRequest("Hubo un error al buscar a la persona");
            }
            var usuario = persona.Usuario;
            if (usuario == null)
            {
                return BadRequest("Hubo un error al buscar al usuario");
            }

            var cantOrdenes = await db.Orden.CountAsync() + 1;
            var orden = new Orden()
            {
                codOrden = "ORD-" + cantOrdenes.ToString("000"),
                Usuario = usuario,
                direccionEntregaOrden = usuario.Persona.direccionPersona,
                fechaEntregaOrden = DateTime.Now,
                fechaPagoOrden = DateTime.Now
            };

            await db.Orden.AddAsync(orden);

            var prods = request.a;
            foreach (var detalle in prods)
            {
                var detalleOrden = await detalleOrdenC.Create(detalle.codProducto, detalle.cantidad, orden);
                if (detalleOrden == null)
                {
                    return BadRequest("Hubo un error al crear la orden");
                }
            }

            await db.SaveChangesAsync();
            return Ok("Orden guardada correctamente");
        }
    }
}
