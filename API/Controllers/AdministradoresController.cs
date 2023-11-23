using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Models;
using API.Atributos;
using Microsoft.EntityFrameworkCore;
using System.Web.Helpers;

namespace API.Controllers
{
    public class AdministradoresController : Controller
    {
        private readonly APIContext db;
        private readonly IWebHostEnvironment env;
        private readonly PersonasController personasC;
        private readonly AuthController authC;

        public AdministradoresController(APIContext context, IWebHostEnvironment env, PersonasController personasController, AuthController authC)
        {
            this.db = context;
            this.env = env;
            this.personasC = personasController;
            this.authC = authC;
        }

        [HttpPost]
        //[Autorizado("administrador")]
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
        [Autorizado("administrador")]
        public async Task<IActionResult> RevisionesPendientes([FromRoute]string cod)
        {
            var token = Request.Headers["Authorization"];
            try
            {
                var persona = await db.TokenGuardado.Include(x => x.Persona.Administrador).FirstOrDefaultAsync(x => x.Token.Equals(token));
                if (persona.Persona.Administrador.codAdmin != cod)
                {
                    return BadRequest("El token es de otro administrador");
                }

                var listaEmpresas = db.Empresa.Where(x => x.ListaEspera.codAdmin.Equals(cod)).Where(x => x.ListaEspera.isAceptado.Equals(false)).Include(x => x.ListaEspera).ToList();

                if (listaEmpresas.Count > 0)
                {
                    var response = new List<InfoEmpresas>();
                    foreach (var emp in listaEmpresas)
                    {
                        var info = new InfoEmpresas()
                        {
                            cod = emp.codEmpresa,
                            nombre = emp.nombreEmpresa,
                            direccion = emp.direccionEmpresa,
                            pathArchivo = emp.archivoVerificacionEmpresa,
                            fechaRevision = emp.ListaEspera.fechaRevision,
                            fechaSolicitud = emp.ListaEspera.fechaSolicitudRevision.ToString("dd-MM-yyyy"),
                            isRevisado = emp.ListaEspera.isAceptado
                        };
                        response.Add(info);
                    }
                    return Ok(response);
                }

                return BadRequest("No hay ninguna empresa asignada a este usuario");
            }
            catch (Exception e)
            {
                return BadRequest("No existe el administrador");
            }
        }

        [HttpGet]
        [Autorizado("administrador")]
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
