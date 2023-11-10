using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Web.Helpers;

namespace API.Controllers
{
    public class Personal_EmpresaController : Controller
    {
        private readonly APIContext db;

        public Personal_EmpresaController(APIContext context)
        {
            db = context;
        }

        public class PersonalRequest
        {
            public string nombre { get; set; }
            public DateTime fechaNac { get; set; }
            public string mail { get; set; }
            public string direccion { get; set; }
            public string user { get; set; }
            public string password { get; set; }
            public string celular { get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]PersonalRequest request, [FromRoute]string cod)
        {
            var empresa = db.Empresa.Include(x => x.ListaEspera).Include(x => x.Personal).FirstOrDefault(x => x.codEmpresa.Equals(cod));
            if(empresa != null)
            {
                var listaEspera = empresa.ListaEspera;
                if (listaEspera != null)
                {
                    var listaPersonal = empresa.Personal.ToList();
                    // el else de esto deberia ser controlado desde el decorador para poder agarrar el estado de la empresa y retornar el unauthorized antes de que se ejecute el metodo
                    var cantPersonas = db.Persona.Count() + 1;
                    Persona persona = new Persona()
                    {
                        codPersona = "PER-" + cantPersonas.ToString("000"),
                        nombrePersona = request.nombre,
                        fechaNacPersona = request.fechaNac,
                        mailPersona = request.mail,
                        direccionPersona = request.direccion,
                        userPersona = request.user,
                        passwordPersona = Crypto.HashPassword(request.password),
                        celularPersona = request.celular
                    };

                    var cantPersonal = db.Personal_Empresa.Count() + 1;
                    Personal_Empresa personal = new Personal_Empresa()
                    {
                        codPersonalEmpresa = "PEM-" + cantPersonal.ToString("000"),
                        codPersona = persona.codPersona,
                        codEmpresa = empresa.codEmpresa
                    };

                    await db.Persona.AddAsync(persona);
                    listaPersonal.Add(personal);
                    await db.Personal_Empresa.AddAsync(personal);

                    await db.SaveChangesAsync();
                    return Ok("Personal añadido correctamente");
                }
                return BadRequest("La empresa tiene que ser revisada primero");
            }
            return BadRequest("Empresa no encontrada");
        }
    }
}
