using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaFinal.Models;
using PruebaFinal.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel;
using System.Web.Helpers;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace PruebaFinal.Controllers
{
    public class AuthController : Controller
    {

        public PruebaFinalContext db;
        private readonly IConfiguration config;
        public AuthController(PruebaFinalContext db, IConfiguration configuration)
        {
            this.db = db;
            this.config = configuration;
        }

        [HttpGet]
        public ActionResult RegistroUsuarios()
        {
            return View("~/Views/Auth/RegistroUsuarios.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> RegistroUsuarios(Persona model)
        {
            var cant = db.Persona.Count();
            var persona = new Persona()
            {
                codPersona = "USU-" + (cant + 1).ToString("000"),
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

            await db.Persona.AddAsync(persona);
            await db.SaveChangesAsync();
            
            return View("Login");
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View("~/Views/Auth/Login.cshtml");
        }

        [HttpPost]
        public IActionResult Login(Persona persona)
        {
            var per = db.Persona.Single(b => b.userPersona == persona.userPersona);


            if(per != null)
            {
                bool usuarioExists = Crypto.VerifyHashedPassword(per.passwordPersona, persona.passwordPersona);

                if(usuarioExists)
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

            return jwt;
        }
    }
}
