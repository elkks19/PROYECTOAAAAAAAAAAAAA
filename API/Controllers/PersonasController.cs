using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Web.Helpers;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;
using System.Globalization;

namespace API.Controllers
{
    [EnableCors]
    public class PersonasController : Controller
    {
        private readonly APIContext db;

        public PersonasController(APIContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<IActionResult> Details(string cod)
        {
            var persona = db.Persona.Where(x => x.codPersona.Equals(cod)).FirstOrDefault();
            if (persona != null)
            {
                return Ok(new
                {
                    userPersona = persona.userPersona,
                    nombrePersona = persona.nombrePersona,
                    apellidosPersona = persona.apPaternoPersona + " " + persona.apMaternoPersona,
                    mailPersona = persona.mailPersona,
                    fechaNacPersona = persona.fechaNacPersona.ToString("yyyy-MM-dd"),
                    direccionPersona = persona.direccionPersona
                });
            }
            return BadRequest("No se encontro al usuario");
        }

        [HttpPatch]
        public async Task<IActionResult> Edit([FromBody] Persona request, [FromRoute] string cod)
        {
            var persona = db.Persona.Where(x => x.codPersona.Equals(cod)).FirstOrDefault();
            if (persona != null)
            {
                if (request.nombrePersona != null) { persona.nombrePersona = request.nombrePersona; }
                if (request.apPaternoPersona != null) { persona.apPaternoPersona = request.apPaternoPersona; }
                if (request.apMaternoPersona != null) { persona.apMaternoPersona = request.apMaternoPersona; }
                if (request.fechaNacPersona != null) { persona.fechaNacPersona = request.fechaNacPersona; }
                if (request.mailPersona != null) { persona.mailPersona = request.mailPersona; }
                if (request.ciPersona != null) { persona.ciPersona = request.ciPersona; }
                if (request.direccionPersona != null) { persona.direccionPersona = request.direccionPersona; }
                if (request.userPersona != null) { persona.userPersona = request.userPersona; }
                db.Persona.Update(persona);
                await db.SaveChangesAsync();
                return Ok("El usuario se edito correctamente");
            }
            return NotFound("El usuario no se encontro");
        }



    }
}
