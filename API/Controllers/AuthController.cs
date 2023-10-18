using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Data;
using System.Web.Helpers;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AuthController : Controller
    {

        public APIContext db;
        private readonly IConfiguration config;
        public AuthController(APIContext db, IConfiguration configuration)
        {
            this.db = db;
            this.config = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> RegistroUsuarios([FromBody] Persona model)
        {
                var cant = db.Persona.Count();
                var persona = new Persona()
                {
                    codPersona = "PER-" + (cant + 1).ToString("000"),
                    nombrePersona = model.nombrePersona,
                    apPaternoPersona = model.apPaternoPersona,
                    apMaternoPersona = model.apMaternoPersona,
                    fechaNacPersona = model.fechaNacPersona,
                    mailPersona = model.mailPersona,
                    ciPersona = model.ciPersona,
                    direccionPersona = model.direccionPersona,
                    userPersona = model.userPersona,
                    passwordPersona = Crypto.HashPassword(model.passwordPersona),
                };

                var countUsu = db.Usuarios.Count();
                var usuario = new Usuario()
                {
                    codUsuario = "USU-" + (countUsu + 1).ToString("000"),
                    Persona = persona,
                    configUsuario = "prueba"
                };

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
        public IActionResult Login([FromBody] PersonaLogin persona)
        {
            var per = db.Persona.Where(b => b.userPersona.Equals(persona.userPersona)).FirstOrDefault();

            if (per != null)
            {
                bool usuarioExists = Crypto.VerifyHashedPassword(per.passwordPersona, persona.passwordPersona);

                if (usuarioExists)
                {
                    string token = CrearToken(per);

                    return Ok(token);
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
                codToken = "TOK-" + cantTok.ToString("000"),
                codPersona = persona.codPersona,
                Token = jwt
            };

            db.TokenGuardado.Add(tokenGuardar);
            db.SaveChanges();

            return jwt;
        }


        public class tokenRequest
        {
            public string token { get; set; }
        }
        [HttpPost]
        public IActionResult Logout([FromBody] tokenRequest req)
        {
            var per = db.TokenGuardado.Where(b => b.Token.Equals(req.token)).FirstOrDefault();
            if(per != null)
            {
                db.TokenGuardado.Remove(per);
                db.SaveChanges();

                return Ok("Se cerro correctamente la sesion");
            }
            return BadRequest("El token no existe");

        }
    }
}
