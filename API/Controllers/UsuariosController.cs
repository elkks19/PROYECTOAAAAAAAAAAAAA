using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;
using System.Text.Json;
using System.Web.Helpers;

namespace API.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly APIContext db;
        public UsuariosController(APIContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<IActionResult> Details(string cod)
        {
            var usuario = db.Usuarios.Include(x => x.Persona).FirstOrDefault(x => x.codUsuario.Equals(cod));
            if (usuario != null)
            {
                var persona = usuario.Persona;
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


        public class PasswordRequest
        {
            public string oldPassword { get; set; }
            public string newPassword { get; set; }
        }

        [HttpPatch]
        public async Task<IActionResult> ChangePassword([FromBody] PasswordRequest request, [FromRoute] string cod)
        {
            if(request.oldPassword == null)
            {
                return BadRequest("Falta el password antiguo");
            }
            if(request.newPassword == null)
            {
                return BadRequest("Falta el password nuevo");
            }
            var usuario = db.Usuarios.Include(x => x.Persona).FirstOrDefault(x => x.codUsuario.Equals(cod));
            if (usuario != null)
            {
                var persona = usuario.Persona;
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
