using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Models;
using API.Atributos;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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

        [HttpGet]
        public async Task<IActionResult> Details([FromRoute]string cod)
        {
            var orden = await db.Orden.Include(x => x.Ordenes).Select(x => new
            {
                fechaPagoOrden = x.fechaPagoOrden.HasValue ? x.fechaPagoOrden.Value.ToString("yyyy-MM-dd") : "No se pago",
                fechaEntregaOrden = x.fechaEntregaOrden.HasValue ? x.fechaEntregaOrden.Value.ToString("yyyy-MM-dd") : "No se entrego",
                x.codOrden,
                x.isCancelada,
                x.codUsuario,
                x.direccionEntregaOrden,
                x.activo
            }).FirstOrDefaultAsync(x => x.codOrden.Equals(cod));

            if (orden.activo == false)
            {
                return BadRequest("Ingrese un codigo de orden activo");
            }

            return Ok(orden);
        }

        [HttpPatch]
        public async Task<IActionResult> Edit([FromRoute]string cod, [FromBody]Orden request)
        {
            var orden = await db.Orden.FirstOrDefaultAsync(x => x.codOrden.Equals(cod));

            if (orden == null || orden.activo == false)
            {
                return BadRequest("Ingrese un codigo de alguna orden activa");
            }

            if (request.codUsuario != null) { orden.codUsuario = request.codUsuario; }
            orden.isCancelada = request.isCancelada;
            if (request.direccionEntregaOrden != null) { orden.direccionEntregaOrden = request.direccionEntregaOrden; }
            if (request.fechaPagoOrden != DateTime.MinValue) { orden.fechaPagoOrden = request.fechaPagoOrden; }

            orden.Update();
            db.Orden.Update(orden);
            await db.SaveChangesAsync();

            return Ok("La orden fue editada correctamente");
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var ordenes = await db.Orden.Include(x => x.Ordenes).Select(x => new
            {
                x.codOrden,
                codEmpresa = x.Ordenes.First().Producto.codEmpresa,
                x.codUsuario,
                x.direccionEntregaOrden,
                fechaPagoOrden = x.fechaPagoOrden.HasValue ? x.fechaPagoOrden.Value.ToString("dd/MM/yyyy hh:mm") : "No se pago",
                fechaEntregaOrden = x.fechaEntregaOrden.HasValue ? x.fechaEntregaOrden.Value.ToString("dd/MM/yyyy hh:mm") : "No se entrego",
                x.isCancelada,
                x.activo,
                createdAt = x.createdAt.ToString("dd/MM/yyyy hh:mm"),
                lastUpdate = x.lastUpdate.ToString("dd/MM/yyyy hh:mm")
            }).Where(x => x.activo.Equals(true)).ToListAsync();

            if (ordenes.Count() == 0)
            {
                return BadRequest("No hay ninguna orden");
            }
            return Ok(ordenes);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute]string cod)
        {
            var orden = await db.Orden.FirstOrDefaultAsync(x => x.codOrden.Equals(cod));

            if (orden == null)
            {
                return BadRequest("No se encontro el detalle orden");
            }

            orden.Desactivar();
            await db.SaveChangesAsync();
            return Ok("La orden fue eliminada correctamente");
        }
    }
}
