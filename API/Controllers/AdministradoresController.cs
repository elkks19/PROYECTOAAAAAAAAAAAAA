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

        public AdministradoresController(APIContext context, IWebHostEnvironment env, PersonasController personasController)
        {
            this.db = context;
            this.env = env;
            this.personasC = personasController;
        }

        [HttpPost]
        //[Autorizado("administrador")]
        public async Task<IActionResult> Registro([FromBody]Persona request)
        {
            var persona = await personasC.Create(request);
            if (persona == null)
            {
                return BadRequest("Hubo un error en el registro");
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
        public async Task<IActionResult> RevisionesPendientes([FromRoute]string cod)
        {
            var listaEmpresas = db.Empresa.Where(x => x.ListaEspera.codAdmin.Equals(cod)).Include(x => x.ListaEspera).ToList();

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
        //public async Task<IActionResult> Create(Administrador request)
        //{

        //}
    }
}
