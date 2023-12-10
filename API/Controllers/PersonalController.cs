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
    public class PersonalController : Controller
    {
        private readonly APIContext db;
        private readonly PersonasController personasC;
        private readonly UsuariosController usuariosC;

        public PersonalController(APIContext context, PersonasController personasController, UsuariosController usuariosC)
        {
            db = context;
            personasC = personasController;
            this.usuariosC = usuariosC;
        }



        protected internal async Task<PersonalEmpresa> Create(Persona request, Empresa empresa)
        {

            var persona = await personasC.Upsert(request);

            var cantPersonal = db.PersonalEmpresa.Count() + 1;
            PersonalEmpresa personal = new PersonalEmpresa()
            {
                codPersonalEmpresa = "PEMP-" + cantPersonal.ToString("000"),
                codPersona = persona.codPersona,
                Empresa = empresa
            };

            await db.PersonalEmpresa.AddAsync(personal);
            await db.SaveChangesAsync();
            return personal;
        }
    }
}
