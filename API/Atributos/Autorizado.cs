using API.Data;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.ComponentModel.DataAnnotations;

namespace API.Atributos
{
    public class Autorizado : Attribute, IAuthorizationFilter
    {
        public APIContext db;
        public Autorizado()
        {
            
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers.ContainsKey("Authorization") || !context.HttpContext.Request.Headers.ContainsKey("codUsu"))
            {
                context.Result = new UnauthorizedResult();
                db = (APIContext)context.HttpContext.RequestServices.GetService(typeof(APIContext));
            }
            else
            {
                var token = context.HttpContext.Request.Headers["Authorization"];
                var tokenExists = db.TokenGuardado.FirstOrDefault(x => x.Token.Equals(token));
                if (tokenExists == null)
                {
                    context.Result = new UnauthorizedResult();
                }
            }
        }
    }
}
