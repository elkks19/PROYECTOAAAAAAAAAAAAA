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
    public class Reclamos_EmpresaController : Controller
    {
        private readonly APIContext db;

        public Reclamos_EmpresaController(APIContext context)
        {
            db = context;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromRoute]string cod, [FromBody]Reclamos_Empresa request)
        {
            var administradores = await db.Administradores.ToListAsync();
            Random rng = new Random();

            var cantReclamos = db.Reclamos_Empresa.Count() + 1;
            var reclamo = new Reclamos_Empresa()
            {
                codReclamo = "REC-" + cantReclamos.ToString("000"),
                codProducto = cod,
                codUsuario = request.codUsuario,
                codAdmin = administradores[rng.Next(administradores.Count)].codAdmin,
                contenidoReclamo = request.contenidoReclamo,
            };
            await db.Reclamos_Empresa.AddAsync(reclamo);
            await db.SaveChangesAsync();
            return Ok(reclamo);
        }


        public class ReclamosResponse
        {
            public string codProducto { get; set; }
            public string codEmpresa { get; set; }
            public string codUsuario { get; set; }
            public string nombreEmpresa { get; set; }
            public string nombreUsuario { get; set; }
            public string contenido { get; set; }
            public string nombreProducto { get; set; }
            public string nombreAdmin { get; set; }
            public DateTime fechaReclamo { get; set; }
        }
        [HttpGet]
        public async Task<IActionResult> GetReclamos([FromRoute] string cod)
        {
            var reclamos = await db.Reclamos_Empresa.Include(x => x.Producto.Empresa).Include(x => x.Administrador.Persona).Include(x => x.Usuario.Persona).Include(x => x.Producto).Where(x => x.codAdmin.Equals(cod)).ToListAsync();
            if (reclamos.Count > 0)
            {
                List<ReclamosResponse> response = new List<ReclamosResponse>();
                foreach (var reclamo in reclamos)
                {
                    ReclamosResponse a = new ReclamosResponse()
                    {
                        codProducto = reclamo.codProducto,
                        codEmpresa = reclamo.Producto.codEmpresa,
                        codUsuario = reclamo.codUsuario,
                        nombreEmpresa = reclamo.Producto.Empresa.nombreEmpresa,
                        nombreUsuario = reclamo.Usuario.Persona.nombrePersona,
                        contenido = reclamo.contenidoReclamo,
                        nombreProducto = reclamo.Producto.nombreProducto,
                        nombreAdmin = reclamo.Administrador.Persona.nombrePersona,
                        fechaReclamo = reclamo.fechaCreacionReclamo
                    };
                    response.Add(a);
                }
                return Ok(response);
            }
            return BadRequest("No se encontro ningun reclamo");
        }
    }
}
