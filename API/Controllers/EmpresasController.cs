using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Models;
using API.Atributos;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;

namespace API.Controllers
{
    public class EmpresasController : Controller
    {
        private readonly APIContext db;
        private readonly IWebHostEnvironment env;
        private readonly ListaEsperaController listaC;
        private readonly PersonalController personalC;
        private readonly UsuariosController usuariosC;

        public EmpresasController(APIContext context, IWebHostEnvironment environment, ListaEsperaController listaEsperaController, PersonalController personalC, UsuariosController usuariosController)
        {
            db = context;
            env = environment;
            listaC = listaEsperaController;
            usuariosC = usuariosController;
            this.personalC = personalC;
        }

        public class RegistroEmpresa
        {
            public string nombreEmpresa { get; set; }
            public string direccionEmpresa { get; set; }
            public string nombrePersona { get; set; }
            public DateTime fechaNacPersona { get; set; }
            public string mailPersona { get; set; }
            public string userPersona { get; set; }
            public string passwordPersona { get; set; }
        }

        [HttpGet]
        public async Task<IActionResult> Productos()
        {
            var token = Request.Headers["Authorization"];
            var persona = await usuariosC.getUsuario(token);

            if (persona == null)
            {
                return BadRequest("No se encontro a la persona");
            }

            await db.Entry(persona).Reference(x => x.PersonalEmpresa).LoadAsync();
            if (persona.PersonalEmpresa == null)
            {
                return BadRequest("Ingrese un personal valido");
            }

            await db.Entry(persona.PersonalEmpresa).Reference(x => x.Empresa).LoadAsync();

            var empresa = persona.PersonalEmpresa.Empresa;

            var productos = await db.Producto.Where(x => x.codEmpresa.Equals(empresa.codEmpresa)).ToListAsync();

            return Ok(productos);
        }

        [HttpPost]
        public async Task<IActionResult> Registro(RegistroEmpresa request)
        {
            string dir = env.ContentRootPath + "\\ArchivosVerificacion";

            if(!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            IFormFile archivo = Request.Form.Files.FirstOrDefault();
            if (archivo == null)
            {
                return BadRequest("No se encontro el archivo de verificacion");
            }

            string path = dir + "\\" + request.nombreEmpresa + "\\" + archivo.FileName;

            if (!Directory.Exists(dir + "\\" + request.nombreEmpresa))
            {
                Directory.CreateDirectory(dir + "\\" + request.nombreEmpresa);
            }

            string[] acceptedExtensions = {"pdf", "png", "jpg", "jpeg"};
            var extension = archivo.FileName.Split(".").Last();
            var ok = Array.Exists(acceptedExtensions, e => e == extension);

            if(archivo.Length > 0)
            {
                if (!ok)
                {
                    return BadRequest("Tipo de archivo invalido");
                }

                if (!System.IO.File.Exists(path))
                {
                    var diskFile = System.IO.File.Create(path);
                    await archivo.CopyToAsync(diskFile);
                    diskFile.Close();
                }

                else
                {
                    var diskFile = System.IO.File.Open(path, FileMode.Open);
                    await archivo.CopyToAsync(diskFile);
                    diskFile.Close();
                }
            }
            else
            {
                return BadRequest("Ingrese un archivo valido");
            }

            var cantEmpresas = db.Empresa.Count() + 1;
            Empresa empresa = new Empresa()
            {
                codEmpresa = "EMP-" + cantEmpresas.ToString("000"),
                nombreEmpresa = request.nombreEmpresa,
                direccionEmpresa = request.direccionEmpresa,
                archivoVerificacionEmpresa = path
            };

            await db.Empresa.AddAsync(empresa);

            await db.SaveChangesAsync();

            PersonalEmpresa personal = await personalC.Create(new Persona()
            {
                nombrePersona = request.nombrePersona,
                direccionPersona = request.direccionEmpresa,
                fechaNacPersona = request.fechaNacPersona,
                mailPersona = request.mailPersona,
                userPersona = request.userPersona,
                passwordPersona = request.passwordPersona
            }, empresa);

            if (personal == null)
            {
                return BadRequest("Hubo un error al registrar la empresa");
            }

            
            var listaEspera = await listaC.Create(empresa);
            if (listaEspera == null)
            {
                return BadRequest("Hubo un error en el registro de la empresa");
            }

            return Ok("Empresa creada correctamente");
        }

        [HttpGet]
        [Autorizado("administrador")]
        public async Task<IActionResult> ArchivoVerificacion([FromRoute]string cod)
        {
            var empresa = await db.Empresa.FirstOrDefaultAsync(x => x.codEmpresa.Equals(cod));

            if (empresa == null)
            {
                return BadRequest("No se encontro la empresa");
            }

            var archivo = System.IO.File.ReadAllBytes(empresa.archivoVerificacionEmpresa);

            var extension = empresa.archivoVerificacionEmpresa.Split(".").Last();

            if (extension == "jpg" || extension == "jpeg" || extension == "png")
            {
                return File(archivo, "image/jpeg");
            }

            if (extension == "pdf")
            {
                return File(archivo, "application/pdf");
            }

            return BadRequest("No es un tipo de archivo valido");

        }


        //
        //  PARA LOS REPORTES
        //
        [HttpGet]
        public async Task<IActionResult> visitas()
        {
            var client = new HttpClient();
            var uri = Environment.GetEnvironmentVariable("RUTA_REPORTES");
            var response = await client.GetAsync($"{uri}/prueba/visitas");

            Stream a = await response.Content.ReadAsStreamAsync();

            return File(a, "application/pdf");
        }
        [HttpGet]
        public async Task<IActionResult> guardados()
        {
            var client = new HttpClient();
            var uri = Environment.GetEnvironmentVariable("RUTA_REPORTES");
            var response = await client.GetAsync($"{uri}/prueba/guardadosWishlist");

            Stream a = await response.Content.ReadAsStreamAsync();

            return File(a, "application/pdf");
        }

        [HttpGet]
        public async Task<IActionResult> usuarios()
        {
            var client = new HttpClient();
            var uri = Environment.GetEnvironmentVariable("RUTA_REPORTES");
            var response = await client.GetAsync($"{uri}/prueba/usuarios");

            Stream a = await response.Content.ReadAsStreamAsync();

            return File(a, "application/pdf");
        }

        [HttpGet]
        public async Task<IActionResult> empresas()
        {
            var client = new HttpClient();
            var uri = Environment.GetEnvironmentVariable("RUTA_REPORTES");
            var response = await client.GetAsync($"{uri}/prueba/empresas");

            Stream a = await response.Content.ReadAsStreamAsync();

            return File(a, "application/pdf");
        }

        [HttpGet]
        public async Task<IActionResult> ventas()
        {
            var client = new HttpClient();
            var uri = Environment.GetEnvironmentVariable("RUTA_REPORTES");
            var response = await client.GetAsync($"{uri}/prueba/ventas");

            Stream a = await response.Content.ReadAsStreamAsync();

            return File(a, "application/pdf");
        }

        //CRUD ACTIONS
        [HttpGet]
        [Autorizado("administrador")]
        public async Task<IActionResult> Index()
        {
            var empresas = db.Empresa.Include(x => x.ListaEspera).Select(x => new
            {
                x.nombreEmpresa,
                x.direccionEmpresa,
                x.activo,
                x.codEmpresa,
                createdAt = x.createdAt.ToString("dd/MM/yyyy HH:mm"),
                lastUpdate = x.lastUpdate.ToString("dd/MM/yyyy HH:mm"),

                listaEspera = new{
                    x.ListaEspera.isAceptado,
                    x.ListaEspera.razonRevision,
                    x.ListaEspera.fechaRevision,
                    x.ListaEspera.fechaSolicitudRevision,
                    x.ListaEspera.codAdmin
                }

            }).Where(x => x.activo.Equals(true));

            if (empresas.Count() == 0)
            {
                return BadRequest("No se encontro ninguna empresa");
            }

            return Ok(empresas);
        }
    }
}
