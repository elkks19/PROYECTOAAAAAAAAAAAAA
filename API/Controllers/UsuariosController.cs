using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;
using API.Atributos;
using NuGet.Protocol.Core.Types;

namespace API.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly APIContext db;
        private readonly IWebHostEnvironment env;
        private readonly PersonasController personasC;
        private readonly LogsAuditoriaController logsC;
        public UsuariosController(APIContext context, IWebHostEnvironment environment, PersonasController personasController, LogsAuditoriaController logsController)
        {
            db = context;
            env = environment;
            personasC = personasController;
            logsC = logsController;
        }
        

        [HttpPost]
        public async Task<IActionResult> Registro([FromBody]Persona request)
        {
            var usuarioExists = await db.Persona.FirstOrDefaultAsync(x => x.userPersona.Equals(request.userPersona));
            if (!(usuarioExists == null))
            {
                return BadRequest("El nombre de usuario ya existe");
            }

            var mailExists = await db.Persona.FirstOrDefaultAsync(x => x.mailPersona.Equals(request.mailPersona));
            if (!(mailExists == null))
            {
                return BadRequest("El email ya existe");
            }

            var persona = await personasC.Create(request);
            if (persona == null)
            {
                return BadRequest("No se pudo registrar a la persona");
            }

            var cantUsuarios = await db.Usuarios.CountAsync() + 1;
            var usuario = new Usuario()
            {
                codUsuario = "USU-" + cantUsuarios.ToString("000"),
                Persona = persona
            };

            var log = await logsC.RegistrarUsuarios(persona);
            if (log == null)
            {
                return BadRequest("No se pudo registrar el log");
            }

            await db.Usuarios.AddAsync(usuario);
            await db.SaveChangesAsync();


            //personasC.EnviarMail(persona, $"Tu cuenta se ha registrado correctamente.\nPara confimar tu corre ingresa al siguiente link:\n\t{}");
            //personasC.EnviarMail(persona, $"Tu cuenta se ha registrado correctamente.\nPara confimar tu corre ingresa al siguiente link:\n\t{}");



            return Ok("Usuario registrado correctamente");
        }

        [HttpGet]
        [Autorizado("administrador")]
        public async Task<IActionResult> Details([FromRoute]string cod)
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
                });
            }
            return BadRequest("No se encontro al usuario");
        }

        [HttpGet]
        public async Task<IActionResult> GetFoto(string cod)
        {
            var foto = await personasC.GetFoto(cod);
            if (foto == null)
            {
                return BadRequest("No se encontro al usuario");
            }
            return File(foto, "image/jpeg");
        }


        public class PasswordRequest
        {
            public string oldPassword { get; set; }
            public string newPassword { get; set; }
        }

        [HttpPatch]
        public async Task<IActionResult> ChangePassword([FromBody]PasswordRequest request, [FromRoute]string cod)
        {
            if (request.oldPassword == null)
            {
                return BadRequest("Falta el password antiguo");
            }
            if (request.newPassword == null)
            {
                return BadRequest("Falta el password nuevo");
            }

            var persona = personasC.ChangePassword(request.oldPassword, request.newPassword, cod);
            if (persona == null)
            {
                return BadRequest("Error al cambiar la contraseña");
            }
            return Ok("Se cambio correctamente la contraseña");
        }


        [HttpPatch]
        public async Task<IActionResult> Edit([FromBody]Persona request, [FromRoute] string cod)
        {
            var usuario = await db.Usuarios.Include(x => x.Persona).FirstOrDefaultAsync(x => x.codUsuario.Equals(cod));

            if (usuario == null)
            {
                return BadRequest("No se encontro al usuario");
            }

            var persona = usuario.Persona;


            IFormFile img = Request.Form.Files.FirstOrDefault();

            var personaEditada = await personasC.Edit(persona, img);
            if (personaEditada == null)
            {
                return BadRequest("Ingrese un mail valido");
            }
            return Ok("Se edito el usuario correctamente");
        }



    }
}
