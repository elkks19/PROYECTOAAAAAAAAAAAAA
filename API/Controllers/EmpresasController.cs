using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Cors;

namespace API.Controllers
{
    public class EmpresasController : Controller
    {
        private readonly APIContext db;
        private readonly IWebHostEnvironment env;

        public EmpresasController(APIContext context, IWebHostEnvironment environment)
        {
            db = context;
            env = environment;
        }

        public class EmpresaRequest
        {
            public string nombre { get; set; }
            public string direccion { get; set; }
            public string nombreArchivo { get; set; }
        }



        
        [HttpPost]
        public async Task<IActionResult> Create(EmpresaRequest request)
        {
            IFormFile archivo = Request.Form.Files.FirstOrDefault();

            string dir = env.ContentRootPath + "/ArchivosVerificacion";

            if(!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            string path = dir + "/" + request.nombre + "/" + archivo.FileName;

            if (!Directory.Exists(dir + "/" + request.nombre))
            {
                Directory.CreateDirectory(dir + "/" + request.nombre);
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
                nombreEmpresa = request.nombre,
                direccionEmpresa = request.direccion,
                archivoVerificacionEmpresa = path
            };

            Random rnd = new Random();
            var admins = db.Administradores.ToList();
            int randomAdmin = rnd.Next(admins.Count);

            Lista_Espera_Empresa listaEspera = new Lista_Espera_Empresa()
            {
                Empresa = empresa,
                codAdmin = admins[randomAdmin].codAdmin
            };



            await db.Lista_Espera_Empresa.AddAsync(listaEspera);
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
