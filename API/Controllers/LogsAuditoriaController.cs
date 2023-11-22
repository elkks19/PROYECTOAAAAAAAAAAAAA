using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class LogsAuditoriaController : Controller
    {
        private readonly APIContext db;

        public LogsAuditoriaController(APIContext context)
        {
            db = context;
        }

        protected internal async Task<LogAuditoria> Logout([FromBody]Persona persona)
        {
            var log = await Create(persona);
            log.accionLog = "Logout";
            await db.LogsAuditoria.AddAsync(log);
            await db.SaveChangesAsync();
            return log;
        }


        private async Task<LogAuditoria> Create(Persona persona)
        {
            var cantLogs = await db.LogsAuditoria.CountAsync() + 1;
            var log = new LogAuditoria()
            {
                codLog = "LOG-" + cantLogs.ToString("000"),
                Persona = persona,
            };
            return log;
        }

        protected internal async Task<LogAuditoria> Login([FromBody]Persona persona)
        {
            var log = await Create(persona);
            log.accionLog = "Login";
            await db.LogsAuditoria.AddAsync(log);
            await db.SaveChangesAsync();
            return log;
        }
        protected internal async Task<LogAuditoria> RegistrarUsuarios([FromBody]Persona persona)
        {
            var log = await Create(persona);
            log.accionLog = "Registro Usuario";
            await db.LogsAuditoria.AddAsync(log);
            await db.SaveChangesAsync();
            return log;
        }
        protected internal async Task<LogAuditoria> RegistrarEmpresa([FromBody]Persona persona)
        {
            var log = await Create(persona);
            log.accionLog = "Registro Empresa";
            await db.LogsAuditoria.AddAsync(log);
            await db.SaveChangesAsync();
            return log;
        }
        protected internal async Task<LogAuditoria> RegistrarPersonal([FromBody]Persona persona)
        {
            var log = await Create(persona);
            log.accionLog = "Registro Personal Empresa";
            await db.LogsAuditoria.AddAsync(log);
            await db.SaveChangesAsync();
            return log;
        }
        protected internal async Task<LogAuditoria> RegistrarAdmin([FromBody]Persona persona)
        {
            var log = await Create(persona);
            log.accionLog = "Registro Administrador";

            await db.LogsAuditoria.AddAsync(log);
            await db.SaveChangesAsync();
            return log;
        }
    }
}
