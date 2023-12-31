﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;

namespace API.Controllers
{
    public class ListaEsperaController : Controller
    {
        private readonly APIContext db;

        public ListaEsperaController(APIContext context)
        {
            db = context;
        }

        protected internal async Task<ListaEsperaEmpresa> Create(Empresa empresa)
        {
            Random rnd = new Random();
            var admins = db.Administradores.ToList();
            int randomAdmin = rnd.Next(admins.Count);

            if (admins.Count == 0)
            {
                return null;
            }

            ListaEsperaEmpresa listaEspera = new ListaEsperaEmpresa()
            {
                Empresa = empresa,
                codAdmin = admins[randomAdmin].codAdmin
            };

            await db.ListaEsperaEmpresa.AddAsync(listaEspera);
            await db.SaveChangesAsync();

            return listaEspera;
        }


        public class ResponseEmpresa
        {
            public string codEmpresa { get; set; }
            public string nombreEmpresa { get; set; }
            public string nombreAdmin { get; set; }
            public bool isRevisado { get; set; }
        }

        protected internal async Task<List<ResponseEmpresa>> Index(string cod)
        {
            var empresas = await db.ListaEsperaEmpresa.Include(x => x.Empresa).Include(x => x.Administrador.Persona).Where(x => x.codAdmin.Equals(cod) && x.isAceptado.Equals(false)).ToListAsync();
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
                        isRevisado = empresa.isAceptado
                    };
                    response.Add(a);
                }
                return response;
            }
            return null;
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
