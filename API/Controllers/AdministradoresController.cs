using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Models;
using API.Atributos;
using Microsoft.EntityFrameworkCore;
using System.Web.Helpers;

namespace API.Controllers
{
    [Autorizado("administrador")]
    public class AdministradoresController : Controller
    {
        private readonly APIContext db;
        private readonly IWebHostEnvironment env;
        private readonly PersonasController personasC;
        private readonly ListaEsperaController listaEsperaC;
        private readonly AuthController authC;
        private readonly UsuariosController usuariosC;

        public AdministradoresController(APIContext context, IWebHostEnvironment env, PersonasController personasController, AuthController authC, UsuariosController usuariosC, ListaEsperaController listaEsperaC)
        {
            this.db = context;
            this.env = env;
            this.personasC = personasController;
            this.authC = authC;
            this.usuariosC = usuariosC;
            this.listaEsperaC = listaEsperaC;
        }

        [HttpPost]
        public async Task<IActionResult> Registro([FromBody]Persona request)
        {
            var persona = await personasC.Create(request);
            if (persona == null)
            {
                return BadRequest("Hubo un error al crear la persona");
            }

            var cantAdmin = await db.Administradores.CountAsync() + 1;
            Administrador admin = new Administrador()
            {
                codAdmin = "ADM-" + cantAdmin.ToString("000"),
                Persona = persona
            };
            await db.Administradores.AddAsync(admin);
            await db.SaveChangesAsync();
            return Ok("El administrador se registro correctemente");
        }


        class InfoEmpresas
        {
            public string cod { get; set; }
            public string nombre { get; set; }
            public string direccion { get; set; }
            public string pathArchivo { get; set; }
            public DateTime? fechaRevision { get; set; }
            public string fechaSolicitud { get; set; }
            public bool isRevisado { get; set; }
        }


        [HttpGet]
        public async Task<IActionResult> RevisionesPendientes()
        {
            var token = Request.Headers["Authorization"];

            var persona = await usuariosC.getUsuario(token);
            if (persona == null)
            {
                return BadRequest("Hubo un error al buscar la persona");
            }
            await db.Entry(persona).Reference(x => x.Administrador).LoadAsync();
            var listaEmpresas = await listaEsperaC.Index(persona.Administrador.codAdmin);
            if (listaEmpresas.Count == 0)
            {
                return Ok("El administrador no tiene ninguna empresa en espera");
            }

            return Ok(listaEmpresas);
        }

        [HttpGet]
        public async Task<IActionResult> UltimoMes()
        {
            var usuarios = await db.Persona.Select(x => new
            {
                x.nombrePersona,
                x.createdAt,
                x.pathFotoPersona,
                x.mailPersona,
                rol = authC.verificarRol(x.userPersona)
            }).Where(x => DateTime.Now.AddDays(-30) <= x.createdAt).ToListAsync();

            var empresas = await db.Empresa.Where(x => DateTime.Now.AddDays(-30) <= x.createdAt).ToListAsync();

            var compradores = usuarios.Where(x => x.rol.Equals("usuario"));

            var ventas = await db.Orden.Include(x => x.Ordenes).Where(x => DateTime.Now.AddDays(-30) <= x.fechaPagoOrden).ToListAsync();

            float total = 0;
            foreach (var venta in ventas)
            {
                foreach (var orden in venta.Ordenes)
                {
                    total += orden.precioTotal;
                }
            }
            return Ok(new
            {
                usuarios = usuarios,
                empresas = empresas,
                compradores = compradores,
                ventasTotales = total
            });
        }
    }
}
