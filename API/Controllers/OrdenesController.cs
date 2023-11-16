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


        public OrdenesController(APIContext context, DetalleOrdenController detalleOrdenController)
        {
            db = context;
            detalleOrdenC = detalleOrdenController;
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
        public async Task<IActionResult> Create([FromBody]OrdenRequest request, [FromRoute]string cod)
        {
            if (request == null)
            {
                return BadRequest("aaaaaaaaaaaa");
            }
            var usuario = await db.Usuarios.Include(x => x.Persona).FirstOrDefaultAsync(x => x.codUsuario.Equals(cod));
            if (usuario == null)
            {
                return BadRequest("No se encontro al usuario");
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

            var prods = request.a;
            foreach (var detalle in prods)
            {
                var detalleOrden = await detalleOrdenC.Create(detalle.codProducto, detalle.cantidad, orden);
                if (detalleOrden == null)
                {
                    return BadRequest("Hubo un error al crear la orden");
                }
            }
            return Ok();
        }
    }
}
