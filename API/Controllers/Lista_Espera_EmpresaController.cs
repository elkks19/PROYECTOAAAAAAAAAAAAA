using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace API.Controllers
{
    public class Lista_Espera_EmpresaController : Controller
    {
        private readonly APIContext db;

        public Lista_Espera_EmpresaController(APIContext context)
        {
            db = context;
        }


        public class ResponseEmpresa
        {
            public string codEmpresa { get; set; }
            public string nombreEmpresa { get; set; }
            public string nombreAdmin { get; set; }
            public bool isRevisado { get; set; }
        }

        public async Task<IActionResult> Index([FromRoute]string cod)
        {
            var empresas = await db.Lista_Espera_Empresa.Include(x => x.Empresa).Include(x => x.Administrador.Persona).Where(x => x.codAdmin.Equals(cod)).ToListAsync();
            if (empresas != null)
            {
                List<ResponseEmpresa> response = new List<ResponseEmpresa>();
                foreach (var empresa in empresas)
                {
                    var a = new ResponseEmpresa()
                    {
                        codEmpresa = empresa.codEmpresa,
                        nombreEmpresa = empresa.Empresa.nombreEmpresa,
                        nombreAdmin = empresa.Administrador.Persona.nombrePersona,
                        isRevisado = empresa.isRevisado
                    };
                    response.Add(a);
                }
                return Ok(response);
            }
            return BadRequest("No se encontro al administrador");
        }

        public async Task<IActionResult> GetArchivo([FromRoute]string cod)
        {
            var empresa = db.Empresa.FirstOrDefault(x => x.codEmpresa.Equals(cod));
            if (empresa != null)
            {
                var b = System.IO.File.ReadAllBytes(empresa.archivoVerificacionEmpresa);
                switch (empresa.archivoVerificacionEmpresa.Split(".").Last())
                {
                    case "pdf":
                        return File(b, "application/pdf");

                    case "jpg": case "jpeg":
                        return File(b, "image/jpeg");

                    case "png":
                        return File(b, "image/png");

                    default:
                        return BadRequest("El formato de archivo es incompatible");
                }
            }
            return BadRequest("No se encontro la empresa");
        }
        
    }
}
