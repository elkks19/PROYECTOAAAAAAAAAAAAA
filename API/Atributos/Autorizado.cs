using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace API.Atributos
{
    public class Autorizado : Attribute, IAuthorizationFilter
    {
        public APIContext db;
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var token = context.HttpContext.Request.Headers["Authorization"];
            var cod = context.HttpContext.Request.RouteValues["cod"].ToString().ToUpper();
            if (token == "" || cod == null)
            {
                context.Result = new UnauthorizedResult();
            }
            else
            {
                db = (APIContext)context.HttpContext.RequestServices.GetService(typeof(APIContext));
                var tokenDB = db.TokenGuardado.Include(x => x.Persona.Usuario).FirstOrDefault(x => x.Token.Equals(token));
                Usuario usuario = null;
                if(tokenDB != null)
                {
                    usuario = tokenDB.Persona.Usuario;
                }
                if (tokenDB == null || usuario == null)
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }
                if(!usuario.codUsuario.Equals(cod))
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }
                return;
            }
        }
    }
}
