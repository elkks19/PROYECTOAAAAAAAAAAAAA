using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;
using API.Atributos;
using Microsoft.CodeAnalysis.Scripting.Hosting;

namespace API.Controllers
{
    public class ProductosController : Controller
    {
        private readonly APIContext db;
        private readonly IWebHostEnvironment env;

        public ProductosController(APIContext context, IWebHostEnvironment env)
        {
            db = context;
            this.env = env;
        }

        //[Autorizado("empresa")]
        public async Task<IActionResult> Create([FromBody]Producto request, [FromRoute]string cod)
        {
            var empresa = await db.Empresa.FirstOrDefaultAsync(x => x.codEmpresa.Equals(cod));
            if (empresa == null)
            {
                return BadRequest("No se encontro la empresa");
            }

            //IFormFile img = Request.Form.Files.FirstOrDefault();

            //var path = $"{env.ContentRootPath}\\ImagenesProductos";
            //if (!Directory.Exists($"{path}\\{empresa.nombreEmpresa}"))
            //{
            //    Directory.CreateDirectory($"{path}\\{empresa.nombreEmpresa}");
            //}

            //if (img.Length == 0)
            //{
            //    return BadRequest("Ingrese un archivo valido");
            //}

            //var file = $"{path}\\{empresa.nombreempresa}\\{img.filename}";

            //if (!System.IO.File.Exists(file))
            //{
            //    var diskFile = System.IO.File.Create(file);
            //    await img.CopyToAsync(diskFile);
            //    diskFile.Close();
            //}
            //else
            //{
            //    var diskFile = System.IO.File.Open(file, FileMode.Open);
            //    await img.CopyToAsync(diskFile);
            //    diskFile.Close();
            //}


            var cantProductos = await db.Producto.CountAsync() + 1;
            var producto = new Producto()
            {
                codProducto = "PROD-" + cantProductos.ToString("000"),
                Empresa = empresa,
                nombreProducto = request.nombreProducto,
                descProducto = request.descProducto,
                precioProducto = request.precioProducto,
                precioEnvioProducto = request.precioEnvioProducto,
                cantidadRestante = request.cantidadRestante,
                pathFotoProducto = env.ContentRootPath + "\\Imagenes\\perrito.jpg"
            };

            await db.Producto.AddAsync(producto);
            await db.SaveChangesAsync();

            return Ok("El producto se registro correctemente");
        }



        public async Task<IActionResult> Details([FromRoute]string cod)
        {
            var prod = await db.Empresa.Include(x => x.Productos).FirstOrDefaultAsync(x => x.codEmpresa.Equals(cod));
            if (prod != null)
            {
                return Ok(prod.Productos.ToList());
            }
            return BadRequest("No se encontro la empresa");
        }

        public async Task<IActionResult> GetFoto([FromRoute]string cod)
        {
            var prod = await db.Producto.FirstOrDefaultAsync(x => x.codProducto.Equals(cod));
            if (prod != null)
            {
                var b = await System.IO.File.ReadAllBytesAsync(prod.pathFotoProducto);
                return File(b, "image/jpeg");
            }

            return BadRequest("No se encontro el producto");
        }

        protected internal async Task<Producto> Disminuir(Producto producto, int cantidad)
        {
            producto.cantidadRestante -= cantidad;
            await db.SaveChangesAsync();
            return producto;
        }
    }
}
