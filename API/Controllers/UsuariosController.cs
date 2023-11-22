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
        [Autorizado(rol2 = "administrador")]
        public async Task<IActionResult> Details()
        {
            var token = Request.Headers["Authorization"];
            var persona = await getUsuario(token);
            if (persona == null)
            {
                return BadRequest("Hubo algun error al buscar al usuario");
            }

            var usuario = persona.Usuario;

            if (usuario != null)
            {
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
        [Autorizado(rol2 = "administrador")]
        public async Task<IActionResult> GetFoto()
        {
            var token = Request.Headers["Authorization"];
            var persona = await getUsuario(token);
            if (persona == null)
            {
                return BadRequest("Hubo un error al buscar la persona");
            }

            var foto = System.IO.File.ReadAllBytes(persona.pathFotoPersona);
            //var foto = await personasC.GetFoto(persona);
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
        [Autorizado(rol2 = "administrador")]
        public async Task<IActionResult> ChangePassword([FromBody]PasswordRequest request)
        {
            var token = Request.Headers["Authorization"];
            var persona = await getUsuario(token);
            if (persona == null)
            {
                return BadRequest("Error al cambiar la contraseña");
            }

            if (request.oldPassword == null)
            {
                return BadRequest("Falta el password antiguo");
            }

            if (request.newPassword == null)
            {
                return BadRequest("Falta el password nuevo");
            }

            var personaEditada = await personasC.ChangePassword(persona, request.oldPassword, request.newPassword);
            if (personaEditada == null)
            {
                return BadRequest("Hubo un error al editar la persona");
            }

            return Ok("Se cambio correctamente la contraseña");
        }


        [HttpPatch]
        [Autorizado(rol2 = "administrador")]
        public async Task<IActionResult> Edit([FromBody]Persona request)
        {
            var token = Request.Headers["Authorization"];
            var persona = await getUsuario(token);

            if (persona == null)
            {
                return BadRequest("Hubo un error al buscar a la persona");
            }

            var personaEditada = await personasC.Edit(persona, request);
            if (personaEditada == null)
            {
                return BadRequest("Ingrese un mail valido");
            }

            return Ok("Se edito el usuario correctamente");
        }

        [HttpPatch]
        [Autorizado(rol2 = "administrador")]
        public async Task<IActionResult> ChangeFoto()
        {
            var token = Request.Headers["Authorization"].FirstOrDefault();
            var persona = await getUsuario(token);
            if (persona == null)
            {
                return BadRequest("Hubo un error al buscar a la persona");
            }

            IFormFile img = Request.Form.Files.FirstOrDefault();

            if (img == null)
            {
                return BadRequest("No se envio una imagen");
            }

            var personaEditada = await personasC.ChangeFoto(persona, img);

            if (personaEditada == null)
            {
                return BadRequest("Hubo un error al cambiar la foto");
            }
            return Ok("La foto se cambio correctamente");
        }


        protected internal async Task<Persona> getUsuario(string token)
        {
            try
            {
                var persona = await db.Persona.Include(x => x.Usuario).FirstOrDefaultAsync(x => x.Token.Token.Equals(token));
                return persona;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
