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
            var producto = await db.Producto.FirstOrDefaultAsync();
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
    }
}
