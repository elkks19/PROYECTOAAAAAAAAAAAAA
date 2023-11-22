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
using System.Configuration;

namespace API.Controllers
{
    public class AuthController : Controller
    {

        public APIContext db;
        private readonly IConfiguration config;
        public readonly LogsAuditoriaController logC;
        private readonly IWebHostEnvironment env;

        public AuthController(APIContext dbContext, IConfiguration configuration, IWebHostEnvironment environment, LogsAuditoriaController logController)
        {
            db = dbContext;
            config = configuration;
            env = environment;
            logC = logController;
        }

        public class PersonaLogin
        {
            public string userPersona { get; set; }
            public string passwordPersona { get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] PersonaLogin persona)
        {
            //retorna un string que dice el rol xd
            var rol = verificarRol(persona.userPersona);
            
            switch (rol)
            {
                case "administrador":
                    var per = await db.Persona.Include(x => x.Administrador).FirstOrDefaultAsync(b => b.userPersona.Equals(persona.userPersona));
                    var admin = per.Administrador;
                    bool usuarioExists = Crypto.VerifyHashedPassword(per.passwordPersona, persona.passwordPersona);
                    if (usuarioExists)
                    {
                        string tok = CrearToken(per);

                        var log = await logC.Login(per);
                        if (log == null)
                        {
                            return BadRequest("Hubo un error al crear el log");
                        }

                        return Ok(new
                        {
                            rol = rol,
                            token = tok,
                        });
                    }
                    else
                    {
                        return BadRequest("Contraseña incorrecta");
                    }


                case "personal":
                    per = await db.Persona.Include(x => x.PersonalEmpresa).FirstOrDefaultAsync(b => b.userPersona.Equals(persona.userPersona));
                    var personal = per.PersonalEmpresa;
                    usuarioExists = Crypto.VerifyHashedPassword(per.passwordPersona, persona.passwordPersona);
                    if (usuarioExists)
                    {
                        string tok = CrearToken(per, per.PersonalEmpresa.codEmpresa);

                        var log = await logC.Login(per);
                        if (log == null)
                        {
                            return BadRequest("Hubo un error al crear el log");
                        }

                        return Ok(new
                        {
                            rol = rol,
                            token = tok,
                        });
                    }
                    else
                    {
                        return BadRequest("Contraseña incorrecta");
                    }

                case "usuario":
                    per = await db.Persona.Include(x => x.Usuario).FirstOrDefaultAsync(b => b.userPersona.Equals(persona.userPersona));
                    usuarioExists = Crypto.VerifyHashedPassword(per.passwordPersona, persona.passwordPersona);

                    var usuario = per.Usuario; 

                    if (usuarioExists)
                    {
                        string tok = CrearToken(per);
                        var log = await logC.Login(per);

                        return Ok(new
                        {
                            rol = rol,
                            token = tok,
                        });
                    }
                    else
                    {
                        return BadRequest("Contraseña incorrecta");
                    }


                default:
                    return BadRequest("El usuario ingresado no existe");

            }
        }

        private string CrearToken(Persona persona, string? codEmpresa = null)
        {
            List<Claim> claims = new List<Claim>();
            if (codEmpresa == null)
            {
                var claim1 = new Claim("codPersona", persona.codPersona);
                claims.Add(claim1);
            }
            else
            {
                var claim1 = new Claim("codPersona", persona.codPersona);
                var claim2 = new Claim("codEmpresa", codEmpresa);
                claims.Add(claim1);
                claims.Add(claim2);
            }

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
                Persona = persona,
                Token = jwt
            };

            db.TokenGuardado.Add(tokenGuardar);
            db.SaveChanges();
            return jwt;
        }


        [HttpPost]
        [Autorizado(rol2 = "administrador", rol3 = "empresa")]
        public async Task<IActionResult> Logout()
        {
            var tok = Request.Headers["Authorization"];
            var token = await db.TokenGuardado.Include(x => x.Persona).FirstOrDefaultAsync(b => b.Token.Equals(tok));

            var cantLogs = db.LogsAuditoria.Count() + 1;
            var log  = await logC.Logout(token.Persona);
            if (log == null)
            {
                return BadRequest("Hubo un error al crear el log");
            }

            db.TokenGuardado.Remove(token);
            await db.SaveChangesAsync();

            return Ok("Se cerro correctamente la sesion");
        }




        public string verificarRol(string codPersona)
        {
            var usuario = db.Usuarios.Include(x => x.Persona).FirstOrDefault(x => x.Persona.userPersona.Equals(codPersona));
            var administrador = db.Administradores.Include(x => x.Persona).FirstOrDefault(x => x.Persona.userPersona.Equals(codPersona));
            var personal = db.PersonalEmpresa.Include(x => x.Persona).FirstOrDefault(x => x.Persona.userPersona.Equals(codPersona));

            if (administrador != null)
            {
                return "administrador";
            }
            else if (usuario != null)
            {
                return "usuario";
            }
            else if (personal != null)
            {
                return "personal";
            }
            else
            {
                return "no";
            }
        }
    }
}
