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
        private readonly IWebHostEnvironment env;
        public UsuariosController(APIContext context, IWebHostEnvironment environment)
        {
            db = context;
            env = environment;
        }

        [HttpGet]
        public async Task<IActionResult> Details(string cod)
        {
            var usuario = db.Usuarios.Include(x => x.Persona).FirstOrDefault(x => x.codUsuario.Equals(cod));
            if (usuario != null)
            {
                var persona = usuario.Persona;
                //var uri = new Uri(Uri.EscapeUriString(usuario.pathFotoUsuario.Replace(Path.DirectorySeparatorChar, '/'))).AbsoluteUri;
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

        [HttpGet]
        public async Task<IActionResult> GetFoto(string cod)
        {
            var usuario = await db.Usuarios.FirstOrDefaultAsync(x => x.codUsuario.Equals(cod));
            if (usuario != null)
            {
                //var b = System.IO.File.ReadAllBytes(usuario.pathFotoUsuario);
                //return Ok(Convert.ToBase64String(b));
                //return File(b, "image/jpeg");
                return Ok(usuario.pathFotoUsuario.ToString());
            }
            return BadRequest("Usuario no encontrado");
        }


        public class PasswordRequest
        {
            public string oldPassword { get; set; }
            public string newPassword { get; set; }
        }

        [HttpPatch]
        public async Task<IActionResult> ChangePassword([FromBody] PasswordRequest request, [FromRoute] string cod)
        {
            if (request.oldPassword == null)
            {
                return BadRequest("Falta el password antiguo");
            }
            if (request.newPassword == null)
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


        [HttpPatch]
        public async Task<IActionResult> Edit([FromBody] Persona request, [FromRoute] string cod)
        {
            //IFormFile img = Request.Form.Files.FirstOrDefault();
            //string dir = env.ContentRootPath + "/Imagenes";

            //if (!Directory.Exists(dir))
            //{
            //    Directory.CreateDirectory(dir);
            //}

            //string path = dir + "/" + cod + "/" + img.FileName;
            //if (!Directory.Exists($"{dir}\\{cod}"))
            //{
            //    Directory.CreateDirectory($"{dir}\\{img.FileName}");
            //    if (img.Length > 0)
            //    {
            //        if (!System.IO.File.Exists(path))
            //        {
            //            var diskImg = System.IO.File.Create(path);
            //            await img.CopyToAsync(diskImg);
            //            diskImg.Close();
            //        }
            //    }
            //}


            var usuario = db.Usuarios.Include(x => x.Persona).FirstOrDefault(x => x.codUsuario.Equals(cod));
            if (usuario != null)
            {
                var persona = usuario.Persona;
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
