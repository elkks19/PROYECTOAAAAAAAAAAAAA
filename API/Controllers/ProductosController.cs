using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;

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
        public async Task<IActionResult> dummyData()
        {
            Producto[] listaProds =
            {
                new Producto(){
                    codProducto = "PROD-001",
                    codEmpresa = "EMP-001",
                    nombreProducto = "Abrigo 1",
                    descProducto = "Abrigo para el frio",
                    precioProducto = 400,
                    envioProducto = 100,
                    pathFotoProducto = env.ContentRootPath + "\\ImgProductos\\PROD-001\\01.jpg"
                },
                new Producto(){
                    codProducto = "PROD-002",
                    codEmpresa = "EMP-001",
                    nombreProducto = "Abrigo 2",
                    descProducto = "Abrigo para mas frio",
                    precioProducto = 200,
                    envioProducto = 200,
                    pathFotoProducto = env.ContentRootPath + "\\ImgProductos\\PROD-002\\02.jpg"
                },
            };
            foreach (Producto p in listaProds)
            {
                await db.Producto.AddAsync(p);
            }
            await db.SaveChangesAsync();
            return Ok("Se guardaron los productos");
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
    }
}
