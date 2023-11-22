using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Models;
using API.Atributos;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;

namespace API.Controllers
{
    public class EmpresasController : Controller
    {
        private readonly APIContext db;
        private readonly IWebHostEnvironment env;
        private readonly ListaEsperaController listaC;

        public EmpresasController(APIContext context, IWebHostEnvironment environment, ListaEsperaController listaEsperaController)
        {
            db = context;
            env = environment;
            listaC = listaEsperaController;
        }

        [HttpPost]
        public async Task<IActionResult> Registro(Empresa request)
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

            var cantEmpresas = db.Empresa.Count() + 1;
            Empresa empresa = new Empresa()
            {
                codEmpresa = "EMP-" + cantEmpresas.ToString("000"),
                nombreEmpresa = request.nombreEmpresa,
                direccionEmpresa = request.direccionEmpresa,
                archivoVerificacionEmpresa = path
            };
            var listaEspera = listaC.Create(empresa);
            if (listaEspera == null)
            {
                return BadRequest("Hubo un error en el registro de la empresa");
            }

            await db.Empresa.AddAsync(empresa);
            await db.SaveChangesAsync();

            return Ok("Empresa creada correctamente");
        }



        [HttpGet]
        public async Task<IActionResult> ReportePrueba()
        {
            var client = new HttpClient();
            var uri = Environment.GetEnvironmentVariable("RUTA_REPORTES");
            var response = await client.GetAsync($"{uri}/prueba/prueba");

            Stream a = await response.Content.ReadAsStreamAsync();

            return File(a, "application/pdf");
        }

    }
}
