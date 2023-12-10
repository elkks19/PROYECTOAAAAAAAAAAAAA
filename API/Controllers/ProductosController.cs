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
        private readonly UsuariosController usuariosC;
        private readonly AuthController authC;

        public ProductosController(APIContext context, IWebHostEnvironment env, UsuariosController usuariosController, AuthController authC)
        {
            db = context;
            this.env = env;
            usuariosC = usuariosController;
            this.authC = authC;
        }


        [HttpGet]
        [Autorizado("usuario")]
        public async Task<IActionResult> Index()
        {
            var token = Request.Headers["Authorization"];
            var persona = await usuariosC.getUsuario(token);

            var rol = authC.verificarRol(persona.userPersona);

            if (rol == "usuario")
            {
                var prods = await db.Producto.Select(x => new
                {
                    x.activo,
                    x.codProducto,
                    x.codEmpresa,
                    x.nombreProducto,
                    x.precioProducto,
                    x.descProducto,
                    x.precioEnvioProducto,
                    x.pathFotoProducto,
                    createdAt = x.createdAt.ToString("dd/MM/yyyy HH:mm:ss"),
                    lastUpdate = x.lastUpdate.ToString("dd/MM/yyyy HH:mm:ss")
                }).Where(x => x.activo.Equals(true)).ToListAsync();
                return Ok(prods);
            }
            else if (rol == "empresa")
            {
                await db.Entry(persona).Reference(x => x.PersonalEmpresa).LoadAsync();
                await db.Entry(persona.PersonalEmpresa).Reference(x => x.Empresa).LoadAsync();
                var cod = persona.PersonalEmpresa.Empresa.codEmpresa;

                var prods = await db.Producto.Select(x => new
                {
                    x.activo,
                    x.codProducto,
                    x.codEmpresa,
                    x.nombreProducto,
                    x.precioProducto,
                    x.descProducto,
                    x.precioEnvioProducto,
                    x.pathFotoProducto,
                    createdAt = x.createdAt.ToString("dd/MM/yyyy HH:mm:ss"),
                    lastUpdate = x.lastUpdate.ToString("dd/MM/yyyy HH:mm:ss")
                }).Where(x => x.activo.Equals(true) && x.codEmpresa.Equals(cod)).ToListAsync();

                return Ok(prods);
            }
            else
            {
                return BadRequest("Ingrese un token de empresa activa");
            }

        }


        [HttpPost]
        [Autorizado("empresa")]
        public async Task<IActionResult> Create(Producto request, [FromRoute]string cod)
        {
            var empresa = await db.Empresa.FirstOrDefaultAsync(x => x.codEmpresa.Equals(cod));
            if (empresa == null)
            {
                return BadRequest("No se encontro la empresa");
            }

            IFormFile img = Request.Form.Files.FirstOrDefault();
            if (img == null)
            {
                return BadRequest("Ingrese una foto");
            }

            var path = $"{env.ContentRootPath}\\ImagenesProductos";
            if (!Directory.Exists($"{path}\\{empresa.nombreEmpresa}"))
            {
                Directory.CreateDirectory($"{path}\\{empresa.nombreEmpresa}");
            }

            if (img.Length == 0)
            {
                return BadRequest("Ingrese un archivo valido");
            }

            var file = $"{path}\\{img.FileName}";

            if (!System.IO.File.Exists(file))
            {
                var diskFile = System.IO.File.Create(file);
                await img.CopyToAsync(diskFile);
                diskFile.Close();
            }
            else
            {
                var diskFile = System.IO.File.Open(file, FileMode.Open);
                await img.CopyToAsync(diskFile);
                diskFile.Close();
            }


            var cantProductos = await db.Producto.CountAsync() + 1;
            var producto = new Producto()
            {
                codProducto = "PRO-" + cantProductos.ToString("000"),
                Empresa = empresa,
                nombreProducto = request.nombreProducto,
                descProducto = request.descProducto,
                precioProducto = request.precioProducto,
                precioEnvioProducto = request.precioEnvioProducto,
                cantidadRestante = request.cantidadRestante,
                pathFotoProducto = file
            };

            await db.Producto.AddAsync(producto);
            await db.SaveChangesAsync();

            return Ok("El producto se registro correctemente");
        }


        [HttpGet]
        [Autorizado("empresa")]
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
            var prods = await db.Producto.Where(x => x.nombreProducto.Contains(request.search) || x.descProducto.Contains(request.search) || x.codEmpresa.Contains(request.search)).ToListAsync();
            if (prods.Count == 0)
            {
                return BadRequest("No se encontro ningun producto");
            }
            return Ok(prods);
        }

        [HttpPost]
        [Autorizado("empresa")]
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
        [Autorizado("empresa")]
        public async Task<IActionResult> Delete([FromRoute]string cod)
        {
            var producto = await db.Producto.FirstOrDefaultAsync(x => x.codProducto.Equals(cod));
            if (producto == null)
            {
                return BadRequest("No se encontró el producto");
            }

            producto.Desactivar();

            await db.SaveChangesAsync();
            return Ok("Se eliminó correctamente el producto");
        }


        [HttpPost]
        [Autorizado("empresa")]
        public async Task<IActionResult> ChangeFoto([FromRoute]string cod)
        {
            var producto = await db.Producto.FirstOrDefaultAsync(x => x.codProducto.Equals(cod));
            
            var img = Request.Form.Files.FirstOrDefault();

            if (img == null)
            {
                return BadRequest("suba una imagen");
            }

            // CREA EL DIRECTORIO IMAGENES SI NO EXISTE
            string dir = env.ContentRootPath + "\\ImagenesProductos";
            if (!Directory.Exists(dir)) { Directory.CreateDirectory(dir); }

            // CREA EL DIRECTORIO CON EL NOMBRE DEL USUARIO Y LA FOTO DE PERFIL
            string path = $"{dir}\\{producto.codProducto}\\{img.FileName}";
            if (!Directory.Exists($"{dir}\\{producto.codProducto}")) { Directory.CreateDirectory($"{dir}\\{producto.codProducto}"); }

            if (img.Length > 0)
            {
                if (!System.IO.File.Exists(path))
                {
                    var diskImg = System.IO.File.Create(path);
                    await img.CopyToAsync(diskImg);
                    producto.pathFotoProducto = path;
                    diskImg.Close();
                }
                else
                {
                    var diskImg = System.IO.File.Open(path, FileMode.Open);
                    await img.CopyToAsync(diskImg);
                    producto.pathFotoProducto = path;
                    diskImg.Close();
                }
            }

            db.Producto.Update(producto);
            producto.Update();

            await db.SaveChangesAsync();
            return Ok("Se guardo correctamente la foto");
        }
    }
}
