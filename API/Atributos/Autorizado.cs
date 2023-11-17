using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace API.Atributos
{
    public class Autorizado : Attribute, IAuthorizationFilter
    {
        public string rol1 { get; } 
        public string rol2 { get; set; }
        public string rol3 { get; set; }

        private APIContext db;
        private JwtSecurityTokenHandler handler;
        private IConfiguration config;
        private string[] roles;

        public Autorizado(string? rol1 = "usuario")
        {
            this.rol1 = rol1;
            roles = new string[] { this.rol1 };
            if (this.rol2 != null)
            {
                this.roles.Append(rol2);
            }
            if (this.rol3 != null)
            {
                this.roles.Append(rol3);
            }
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string token = context.HttpContext.Request.Headers["Authorization"];
            string codPersonaReq = context.HttpContext.Request.Headers["codPersona"];
            if (token == null || codPersonaReq == null)
            {
                context.Result = new UnauthorizedResult();
            }

            db = (APIContext)context.HttpContext.RequestServices.GetService(typeof(APIContext));
            if (db == null)
            {
                context.Result = new UnauthorizedResult();
            }

            var persona = db.Persona.Include(x => x.Usuario).Include(x => x.Administrador).Include(x => x.PersonalEmpresa).Include(x => x.Token).FirstOrDefault(x => x.codPersona.Equals(codPersonaReq));
            if (persona == null)
            {
                context.Result = new UnauthorizedResult();
            }
            // Se verifica que la persona del codigo exista y que este en la tabla de tokens
            
            var tokenFin = persona.Token;
            if (persona.codPersona != codPersonaReq || tokenFin == null)
            {
                context.Result = new UnauthorizedResult();
            }

            var admin = persona.Administrador;
            var personal = persona.PersonalEmpresa;
            var usuario = persona.Usuario;

            if (admin == null && this.roles.Contains("administrador"))
            {
                context.Result = new UnauthorizedResult();
            }
            if (personal == null && this.roles.Contains("empresa"))
            {
                context.Result = new UnauthorizedResult();
            }
            if (usuario == null && this.roles.Contains("usuario"))
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
