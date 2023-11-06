using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using System.Web.Helpers;
using API.Atributos;

namespace API.Controllers
{
    [Autorizado]
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
                return Ok(new
                {
                    userPersona = persona.userPersona,
                    nombrePersona = persona.nombrePersona,
                    mailPersona = persona.mailPersona,
                    fechaNacPersona = persona.fechaNacPersona.ToString("yyyy-MM-dd"),
                    direccionPersona = persona.direccionPersona,
                    celularPersona = persona.celularPersona,
                    configUsuario = usuario.configUsuario
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
                var b = System.IO.File.ReadAllBytes(usuario.pathFotoUsuario);
                return File(b, "image/jpeg");
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

        public class UserEditRequest
        {
            public string nombrePersona { get; set; }
            public DateTime fechaNacPersona { get; set; }
            public string mailPersona { get; set; }
            public string direccionPersona { get; set; }
            public string userPersona { get; set; }
            public string celularPersona { get; set; }
            public string configUsuario { get; set; }

        }

        [HttpPatch]
        public async Task<IActionResult> Edit(UserEditRequest request, [FromRoute] string cod)
        {
            IFormFile img = Request.Form.Files.FirstOrDefault();

            var usuario = db.Usuarios.Include(x => x.Persona).FirstOrDefault(x => x.codUsuario.Equals(cod));

            if (usuario != null)
            {
                var persona = usuario.Persona;

                if (img != null)
                {
                    // CREA EL DIRECTORIO IMAGENES SI NO EXISTE
                    string dir = env.ContentRootPath + "\\Imagenes";
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }


                    // CREA EL DIRECTORIO CON EL NOMBRE DEL USUARIO Y LA FOTO DE PERFIL
                    string path = dir + "\\" + cod + "\\" + img.FileName;  
                    if (!Directory.Exists($"{dir}\\{cod}"))
                    {
                        Directory.CreateDirectory($"{dir}\\{cod}");
                    }

                    if (img.Length > 0)
                    {
                        if (!System.IO.File.Exists(path))
                        {
                            var diskImg = System.IO.File.Create(path);
                            await img.CopyToAsync(diskImg);
                            usuario.pathFotoUsuario = path;
                            diskImg.Close();
                        }
                        else
                        {
                            var diskImg = System.IO.File.Open(path, FileMode.Open);
                            await img.CopyToAsync(diskImg);
                            usuario.pathFotoUsuario = path;
                            diskImg.Close();
                        }
                    }
                }
                if (request.nombrePersona != null) { persona.nombrePersona = request.nombrePersona; }
                if (request.fechaNacPersona != DateTime.MinValue) { persona.fechaNacPersona = request.fechaNacPersona; }
                if (request.mailPersona != null) { persona.mailPersona = request.mailPersona; }
                if (request.direccionPersona != null) { persona.direccionPersona = request.direccionPersona; }
                if (request.userPersona != null) { persona.userPersona = request.userPersona; }
                if (request.celularPersona != null) { persona.celularPersona = request.celularPersona; }
                if (request.configUsuario != null) { usuario.configUsuario = request.configUsuario; }
                db.Persona.Update(persona);
                persona.Update();
                await db.SaveChangesAsync();
                return Ok("El usuario se edito correctamente");
            }
            return NotFound("El usuario no se encontro");
        }
    }
}
