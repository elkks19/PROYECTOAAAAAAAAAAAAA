using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Data;
using System.Web.Helpers;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;
using API.Atributos;

namespace API.Controllers
{
    public class AuthController : Controller
    {

        public APIContext db;
        private readonly IConfiguration config;
        private IWebHostEnvironment env;
        public AuthController(APIContext db, IConfiguration configuration, IWebHostEnvironment environment)
        {
            this.db = db;
            this.config = configuration;
            this.env = environment;
        }

        [HttpPost]
        public async Task<IActionResult> RegistroUsuarios([FromBody] Persona model)
        {
            var cantPersonas = db.Persona.Count();
            var persona = new Persona()
            {
                nombrePersona = model.nombrePersona,
                fechaNacPersona = model.fechaNacPersona,
                mailPersona = model.mailPersona,
                direccionPersona = model.direccionPersona,
                userPersona = model.userPersona,
                passwordPersona = Crypto.HashPassword(model.passwordPersona),
            };

            var countUsu = db.Usuarios.Count() + 1;
            var usuario = new Usuario()
            {
                Persona = persona,
            };

            var cantLogs = db.LogsAuditoria.Count() + 1;
            var log = new LogAuditoria()
            {
                codLog = "LOG-" + cantLogs.ToString("000"),
                Persona = persona,
                accionLog = "Registro"
            };

            await db.LogsAuditoria.AddAsync(log);
            await db.Persona.AddAsync(persona);
            await db.Usuarios.AddAsync(usuario);
            await db.SaveChangesAsync();

            return Ok("Se registro el usuario correctamente");
        }


        public class PersonaLogin
        {
            public string userPersona { get; set; }
            public string passwordPersona { get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] PersonaLogin persona)
        {
            var per = db.Persona.Include(x => x.Usuario).FirstOrDefault(b => b.userPersona.Equals(persona.userPersona));

            if (per != null)
            {
                bool usuarioExists = Crypto.VerifyHashedPassword(per.passwordPersona, persona.passwordPersona);

                var usuario = per.Usuario; 

                if (usuarioExists)
                {
                    string tok = CrearToken(per);

                    var cantLogs = db.LogsAuditoria.Count() + 1;
                    var log = new LogAuditoria()
                    {
                        Persona = per,
                        accionLog = "Login"
                    };
                    await db.LogsAuditoria.AddAsync(log);
                    await db.SaveChangesAsync();

                    return Ok(new
                    {
                        token = tok,
                        codUsu = usuario.codUsuario
                    });
                }
                else
                {
                    return BadRequest("Contraseña incorrecta");
                }
            }
            else
            {
                return BadRequest("El usuario no existe");
            }
        }

        private string CrearToken(Persona persona)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, persona.userPersona)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            var cantTok = db.TokenGuardado.Count() + 1;
            var tokenGuardar = new TokenGuardado()
            {
                codPersona = persona.codPersona,
                Token = jwt
            };

            db.TokenGuardado.Add(tokenGuardar);
            db.SaveChanges();

            return jwt;
        }


        [HttpPost]
        [Autorizado]
        public async Task<IActionResult> Logout()
        {
            var tok = Request.Headers["Authorization"];
            var token = db.TokenGuardado.Include(x => x.Persona).Where(b => b.Token.Equals(tok)).FirstOrDefault();

            if(token != null)
            {
                var cantLog = db.LogsAuditoria.Count() + 1;
                var log = new LogAuditoria()
                {
                    Persona = token.Persona,
                    accionLog = "Logout"
                };
                await db.LogsAuditoria.AddAsync(log);
                db.TokenGuardado.Remove(token);
                await db.SaveChangesAsync();

                return Ok("Se cerro correctamente la sesion");
            }
            return BadRequest("El token no existe");

        }
    }
}
