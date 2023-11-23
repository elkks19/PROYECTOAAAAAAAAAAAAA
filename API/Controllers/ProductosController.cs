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
using Microsoft.AspNetCore.Authorization;

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

        [HttpGet]
        [Autorizado(rol2 = "empresa", rol3 = "administrador")]
        public async Task<IActionResult> GetAll()
        {
            var productos = await db.Producto.ToListAsync();
            if (productos == null)
            {
                return BadRequest("No se encontró ningun producto");
            }

            return Ok(productos);
        }


        [HttpPost]
        [Autorizado("empresa", rol2 = "administrador")]
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


        [HttpGet]
        [Autorizado(rol2 = "empresa", rol3= "administrador")]
        public async Task<IActionResult> Details([FromRoute]string cod)
        {
            var prod = await db.Producto.FirstOrDefaultAsync(x => x.codProducto.Equals(cod));
            if (prod == null)
            {
                return BadRequest("No se encontro la empresa");
            }
            return Ok(prod);
        }

        [HttpGet]
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



        public class Busqueda
        {
            public string search { get; set; }
        }
        [HttpPost]
        [Autorizado]
        public async Task<IActionResult> Search([FromBody]Busqueda request)
        {
            if (String.IsNullOrEmpty(request.search))
            {
                var prod = await db.Producto.ToListAsync();
                return Ok(prod);
            }
            var prods = await db.Producto.Where(x => x.nombreProducto.Contains(request.search) || x.descProducto.Contains(request.search)).ToListAsync();
            if (prods.Count == 0)
            {
                return BadRequest("No se encontro ningun producto");
            }
            return Ok(prods);
        }
    }
}
