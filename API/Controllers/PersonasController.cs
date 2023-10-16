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
                    user = persona.userPersona,
                    nombres = persona.nombrePersona,
                    apellidos = persona.apPaternoPersona + " " + persona.apMaternoPersona,
                    mail = persona.mailPersona,
                    fechaNac = persona.fechaNacPersona.ToString("yyyy-MM-dd"),
                    direccion = persona.direccionPersona
                });
            }
            return BadRequest("No se encontro al usuario");
        }

        [HttpPatch]
        public async Task<IActionResult> Edit([FromBody] Persona request)
        {
            var persona = db.Persona.Where(x => x.codPersona.Equals(request.codPersona)).FirstOrDefault();
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


        public class PasswordRequest
        {
            public string codPersona { get; set; }
            public string oldPassword { get; set; }
            public string newPassword { get; set; }
        }

        [HttpPatch]
        public async Task<IActionResult> ChangePassword([FromBody] PasswordRequest request)
        {
            if(request.oldPassword == null)
            {
                return BadRequest("Falta el password antiguo");
            }
            if(request.newPassword == null)
            {
                return BadRequest("Falta el password nuevo");
            }
            var persona = db.Persona.Where(x => x.codPersona.Equals(request.codPersona)).FirstOrDefault();
            if (persona != null)
            {
                var correctPassword = Crypto.VerifyHashedPassword(persona.passwordPersona, request.oldPassword);
                
                if (correctPassword)
                {
                    persona.passwordPersona = Crypto.HashPassword(request.newPassword);
                    await db.SaveChangesAsync();
                    return Ok("Se cambio correctamente la contraseña");

                }
                return BadRequest("Contraseña equivocada");
            }
            return BadRequest("No se encontro el usuario");
        }
    }
}
