using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class DetalleOrdenController : Controller
    {
        private readonly APIContext db;
        private readonly ProductosController prodC;

        public DetalleOrdenController(APIContext context, ProductosController prodC)
        {
            db = context;
            this.prodC = prodC;
        }

        protected internal async Task<DetalleOrden> Create(string codProducto, int cantidad, Orden orden)
        {
            var producto = await db.Producto.FirstOrDefaultAsync(x => x.codProducto.Equals(codProducto));
            if (producto == null)
            {
                return null;
            }
            var cantDetalleOrdenes = await db.DetalleOrden.CountAsync() + 1;
            var detalleOrden = new DetalleOrden()
            {
                codDetalleOrden = "DETO-" + cantDetalleOrdenes.ToString("000"),
                Orden = orden,
                Producto = producto,
                cantidadProducto = cantidad,
                precioTotal = producto.precioProducto * cantidad
            };
            await prodC.Disminuir(producto, cantidad);
            await db.DetalleOrden.AddAsync(detalleOrden);
            await db.SaveChangesAsync();
            return detalleOrden;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromRoute]string cod)
        {
            var ordenes = await db.DetalleOrden.Include(x => x.Producto).Include(x => x.Orden).Select(x => new
            {
                x.codDetalleOrden,
                x.codProducto,
                x.cantidadProducto,
                precioUnitario = x.Producto.precioProducto,
                x.codOrden,
                x.Orden,
                x.precioTotal
            }).Where(x => x.codOrden.Equals(cod)).ToListAsync();

            if (ordenes.Count() == 0)
            {
                return BadRequest("No se encontro ningun detalle para esta orden");
            }

            if (ordenes[0].Orden.activo == false)
            {
                return BadRequest("No es una orden activa");
            }

            return Ok(ordenes);
        }

        [HttpGet]
        public async Task<IActionResult> Details([FromRoute]string cod)
        {
            var detalle = await db.DetalleOrden.Include(x => x.Producto).Select(x => new
            {
                x.codDetalleOrden,
                x.cantidadProducto,
                x.codProducto,
                precioUnitario = x.Producto.precioProducto,
                x.precioTotal
            }).FirstOrDefaultAsync(x => x.codDetalleOrden.Equals(cod));
            if (detalle == null)
            {
                return BadRequest("No se encontro el detalle orden");
            }

            return Ok(detalle);
        }

        [HttpPatch]
        public async Task<IActionResult> Edit([FromRoute]string cod, [FromBody]DetalleOrden request)
        {
            var detalle = await db.DetalleOrden.FirstOrDefaultAsync(x => x.codDetalleOrden.Equals(cod));

            if (detalle == null)
            {
                return BadRequest("No se encontro el detalle orden");
            }

            if (request.codProducto != null) { detalle.codProducto = request.codProducto; }
            if (request.cantidadProducto != 0) { detalle.cantidadProducto = request.cantidadProducto; }

            db.DetalleOrden.Update(detalle);
            await db.SaveChangesAsync();

            return Ok("El detalle fue editado correctamente");
        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute]string cod)
        {
            var detalle = await db.DetalleOrden.FirstOrDefaultAsync(x => x.codDetalleOrden.Equals(cod));
            if (detalle == null)
            {
                return BadRequest("No se encontro el detalle");
            }
            db.DetalleOrden.Remove(detalle);
            await db.SaveChangesAsync();
            return Ok("El detalle se elimino correctamente");
        }
    }
}
