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
        private IWebHostEnvironment env;
        public AuthController(APIContext db, IConfiguration configuration, IWebHostEnvironment environment)
        {
            this.db = db;
            this.config = configuration;
            this.env = environment;
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

                        var cantLogs = await db.LogsAuditoria.CountAsync() + 1;
                        var log = new LogAuditoria()
                        {
                            codLog = "LOG-" + cantLogs.ToString("000"),
                            Persona = per,
                            accionLog = "Login",
                        };
                        await db.LogsAuditoria.AddAsync(log);
                        await db.SaveChangesAsync();
                        return Ok(new
                        {
                            token = tok,
                            rol = "administrador"
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
                        string tok = CrearToken(per);

                        var cantLogs = await db.LogsAuditoria.CountAsync() + 1;
                        var log = new LogAuditoria()
                        {
                            codLog = "LOG-" + cantLogs.ToString("000"),
                            Persona = per,
                            accionLog = "Login",
                        };
                        await db.LogsAuditoria.AddAsync(log);
                        await db.SaveChangesAsync();
                        return Ok(new
                        {
                            token = tok,
                            rol = "personal"
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

                        var cantLogs = await db.LogsAuditoria.CountAsync() + 1;
                        var log = new LogAuditoria()
                        {
                            codLog = "LOG-" + cantLogs.ToString("000"),
                            Persona = per,
                            accionLog = "Login"
                        };
                        await db.LogsAuditoria.AddAsync(log);
                        await db.SaveChangesAsync();

                        return Ok(new
                        {
                            token = tok,
                            rol = "usuario"
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

        private string CrearToken(Persona persona)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, persona.codPersona)
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


        [HttpPost]
        [Autorizado]
        public async Task<IActionResult> Logout()
        {
            var tok = Request.Headers["Authorization"];
            var token = await db.TokenGuardado.Include(x => x.Persona).FirstOrDefaultAsync(b => b.Token.Equals(tok));

            if(token != null)
            {
                var cantLogs = db.LogsAuditoria.Count() + 1;
                var log = new LogAuditoria()
                {
                    codLog = "LOG-" + cantLogs.ToString("000"),
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




        public string verificarRol(string codPersona)
        {
            var usuario = db.Usuarios.Include(x => x.Persona).FirstOrDefault(x => x.Persona.userPersona.Equals(codPersona));
            var administrador = db.Administradores.Include(x => x.Persona).FirstOrDefault(x => x.Persona.userPersona.Equals(codPersona));
            var personal = db.PersonalEmpresa.Include(x => x.Persona).FirstOrDefault(x => x.Persona.userPersona.Equals(codPersona));

            if (usuario != null)
            {
                return "usuario";
            }
            else if (administrador != null)
            {
                return "administrador";
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
