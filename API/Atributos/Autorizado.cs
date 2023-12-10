using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Abstractions;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace API.Atributos
{
    public class Autorizado : Attribute, IAsyncAuthorizationFilter
    {
        public string rol1 { get; set; }
        public string? rol2 { get; set; }
        public JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

        private APIContext db;
        private List<string> roles;

        public Autorizado(string? rol1 = "usuario")
        {
            this.rol1 = rol1;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            try
            {
                roles = new List<string>();
                this.roles.Add(this.rol1);
                this.roles.Add(this.rol2);
                this.roles.Add("administrador");

                db = (APIContext)context.HttpContext.RequestServices.GetService(typeof(APIContext));
                if (db == null)
                {
                    context.Result = new UnauthorizedResult();
                }

                string token = context.HttpContext.Request.Headers["Authorization"];

                if (token == null)
                {
                    context.Result = new UnauthorizedResult();
                }

                var tok = handler.ReadJwtToken(token);
                var claimCod = tok.Claims.Where(x => x.Type.Equals("codPersona")).FirstOrDefault();

                if (claimCod == null)
                {
                    context.Result = new UnauthorizedResult();
                }

                var codRequest = claimCod.Value;

                var persona = await db.Persona.FirstOrDefaultAsync(x => x.codPersona.Equals(codRequest));

                if (persona == null)
                {
                    context.Result = new UnauthorizedResult();
                }
                // Se verifica que la persona del codigo exista y que este en la tabla de tokens


                var tokenExists = await db.TokenGuardado.Include(x => x.Persona).FirstOrDefaultAsync(x => x.Token.Equals(token));
                if (tokenExists == null)
                {
                    context.Result = new UnauthorizedResult();
                }
                var personaToken = tokenExists.Persona;

                if (personaToken.codPersona != codRequest || personaToken == null)
                {
                    context.Result = new UnauthorizedResult();
                }

                if (this.roles.Contains("administrador"))
                {
                    await db.Entry(persona).Reference(x => x.Administrador).LoadAsync();
                    if (persona.Administrador != null)
                    {
                        return;
                    }
                }

                if (this.roles.Contains("empresa"))
                {
                    await db.Entry(persona).Reference(x => x.PersonalEmpresa).LoadAsync();


                    if (persona.PersonalEmpresa != null)
                    {
                        await db.Entry(persona.PersonalEmpresa).Reference(x => x.Empresa).LoadAsync();
                        var empresa = persona.PersonalEmpresa.Empresa;

                        if (empresa.activo == false)
                        {
                            context.Result = new UnauthorizedResult();
                        }

                        await db.Entry(empresa).Reference(x => x.ListaEspera).LoadAsync();
                        if (empresa.ListaEspera.isAceptado == false)
                        {
                            context.Result = new UnauthorizedResult();
                        }
                        var codEmpresa = tok.Claims.FirstOrDefault(x => x.Type.Equals("codEmpresa")).Value;
                        if (persona.PersonalEmpresa.codEmpresa != codEmpresa)
                        {
                            context.Result = new UnauthorizedResult();
                        }
                        return;
                    }
                }
                if (this.roles.Contains("usuario"))
                {
                    await db.Entry(persona).Reference(x => x.Usuario).LoadAsync();
                    if (persona.Usuario != null)
                    {
                        return;
                    }
                }
                context.Result = new UnauthorizedResult();
        }
            catch (Exception e)
            {
                context.Result = new UnauthorizedResult();
    }
}
    }
}
