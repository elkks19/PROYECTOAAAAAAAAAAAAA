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
using Microsoft.CodeAnalysis.Elfie.Diagnostics;

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


        public async Task<IActionResult> Dummy()
        {
            var productos = new List<Producto>()
            {
                new Producto()
                {
                    codProducto = "PRO-001",
                    codEmpresa = "EMP-001",
                    nombreProducto = "BodyRojo",
                    descProducto = "Body rojo para mujer talla xs, hasta s",
                    precioProducto = 50,
                    precioEnvioProducto = 40,
                    pathFotoProducto = env.ContentRootPath + "\\ImagenesProducto\\bodyRojo.jpg",
                    cantidadRestante = 5,
                    createdAt = DateTime.Now,
                    lastUpdate = DateTime.Now
                },
                new Producto()
                {
                    codProducto = "PRO-002",
                    codEmpresa = "EMP-001",
                    nombreProducto = "Faldas de tonos café",
                    descProducto = "Faldas de tonos café",
                    precioProducto = 70,
                    precioEnvioProducto = 10,
                    pathFotoProducto = env.ContentRootPath + "\\ImagenesProducto\\faldas.jpg",
                    cantidadRestante = 4,
                    createdAt = DateTime.Now,
                    lastUpdate = DateTime.Now
                },
                new Producto()
                {
                    codProducto = "PRO-003",
                    codEmpresa = "EMP-001",
                    nombreProducto = "Jeans",
                    descProducto = "Jeans para mujer",
                    precioProducto = 70,
                    precioEnvioProducto = 20,
                    pathFotoProducto = env.ContentRootPath + "\\ImagenesProducto\\jeans.jpg",
                    cantidadRestante = 10,
                    createdAt = DateTime.Now,
                    lastUpdate = DateTime.Now
                },
                new Producto()
                {
                    codProducto = "PRO-004",
                    codEmpresa = "EMP-001",
                    nombreProducto = "Camisas a cuadros",
                    descProducto = "Camisas a cuadros para mujer",
                    precioProducto = 20,
                    precioEnvioProducto = 5,
                    pathFotoProducto = env.ContentRootPath + "\\ImagenesProducto\\camisas.jpg",
                    cantidadRestante = 15,
                    createdAt = DateTime.Now,
                    lastUpdate = DateTime.Now
                }
            };
            foreach(var producto in productos)
            {
                await db.Producto.AddAsync(producto);
            }
            await db.SaveChangesAsync();
            return Ok("Se añadieron los productos");
        }





        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var prods = await db.Producto.Select(x => new
            {
                x.codProducto,
                x.codEmpresa,
                x.nombreProducto,
                x.precioProducto,
                x.descProducto,
                x.precioEnvioProducto,
                createdAt = x.createdAt.ToString("dd/MM/yyyy HH:mm:ss"),
                lastUpdate = x.lastUpdate.ToString("dd/MM/yyyy HH:mm:ss")
            }).ToListAsync();

            return Ok(prods);
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

        [HttpPost]
        public async Task<IActionResult> Edit([FromBody]Producto request, [FromRoute]string cod)
        {
            var producto = await db.Producto.FirstOrDefaultAsync(x => x.codProducto.Equals(cod));
            if (producto == null)
            {
                return BadRequest("No se encontro el producto");
            }
            if (request.codEmpresa != null) { producto.codEmpresa = request.codEmpresa; }
            if (request.nombreProducto != null) { producto.nombreProducto = request.nombreProducto; }
            if (request.descProducto != null) { producto.descProducto = request.descProducto; }
            if (request.precioProducto != 0) { request.precioProducto = request.precioProducto; }
            if (request.precioEnvioProducto != 0) { request.precioEnvioProducto = request.precioEnvioProducto; }
            producto.Update();
            await db.SaveChangesAsync();
            return Ok("El producto se editó correctamente");
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute]string cod)
        {
            var producto = await db.Producto.FirstOrDefaultAsync(x => x.codProducto.Equals(cod));
            if (producto == null)
            {
                return BadRequest("No se encontró el producto");
            }
            db.Producto.Remove(producto);
            await db.SaveChangesAsync();
            return Ok("Se eliminó correctamente el producto");
        }


    }
}
