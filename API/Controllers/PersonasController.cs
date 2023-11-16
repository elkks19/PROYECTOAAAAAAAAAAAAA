using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System.Web.Helpers;
using MimeKit;
using MailKit.Net.Smtp;

namespace API.Controllers
{
    public class PersonasController : Controller
    {
        private readonly APIContext db;
        private readonly IWebHostEnvironment env;

        public PersonasController(APIContext context, IWebHostEnvironment environment)
        {
            db = context;
            env = environment;
        }


        protected internal async Task<byte[]> GetFoto(string cod)
        {
            var persona = await db.Persona.FindAsync(cod);
            if (persona == null)
            {
                return null;
            }
            var imagen = System.IO.File.ReadAllBytes(persona.pathFotoPersona);
            return imagen;
        }

        protected internal async Task<Persona> ChangePassword(string oldPassword, string newPassword, string cod)
        {
            if (oldPassword == null)
            {
                return null;
            }
            if (newPassword == null)
            {
                return null;
            }

            var persona = await db.Persona.FindAsync(cod);
            if (persona == null)
            {
                return null;
            }

            var correctPassword = Crypto.VerifyHashedPassword(persona.passwordPersona, oldPassword);
            if (!correctPassword)
            {
                return null;
            }
            persona.passwordPersona = Crypto.HashPassword(newPassword);
            await db.SaveChangesAsync();
            return persona;
        }

        protected internal async Task<Persona> Create(Persona request)
        {
            var cantPersonas = await db.Persona.CountAsync() + 1;
            if (!IsValidEmail(request.mailPersona))
            {
                return null;
            }

            var persona = new Persona()
            {
                codPersona = "PER-" + cantPersonas.ToString("000"),
                userPersona = request.userPersona,
                passwordPersona = Crypto.HashPassword(request.passwordPersona),
                nombrePersona = request.nombrePersona,
                fechaNacPersona = request.fechaNacPersona,
                mailPersona = request.mailPersona,
                direccionPersona = request.direccionPersona,
                pathFotoPersona = env.ContentRootPath + "\\Imagenes\\perrito.jpg"
            };
            await db.Persona.AddAsync(persona);
            await db.SaveChangesAsync();
            return persona;
        }

        protected internal async Task<Persona> Edit(Persona request, IFormFile img)
        {
            var persona = db.Persona.FirstOrDefault(x => x.codPersona.Equals(request.codPersona));

            if (img != null)
            {
                // CREA EL DIRECTORIO IMAGENES SI NO EXISTE
                string dir = env.ContentRootPath + "\\Imagenes";
                if (!Directory.Exists(dir)) { Directory.CreateDirectory(dir); }

                // CREA EL DIRECTORIO CON EL NOMBRE DEL USUARIO Y LA FOTO DE PERFIL
                string path = $"{dir}\\{request.codPersona}\\{img.FileName}";
                if (!Directory.Exists($"{dir}\\{request.codPersona}")) { Directory.CreateDirectory($"{dir}\\{request.codPersona}"); }

                if (img.Length > 0)
                {
                    if (!System.IO.File.Exists(path))
                    {
                        var diskImg = System.IO.File.Create(path);
                        await img.CopyToAsync(diskImg);
                        persona.pathFotoPersona = path;
                        diskImg.Close();
                    }
                    else
                    {
                        var diskImg = System.IO.File.Open(path, FileMode.Open);
                        await img.CopyToAsync(diskImg);
                        persona.pathFotoPersona = path;
                        diskImg.Close();
                    }
                }
            }

            if (request.nombrePersona != null) { persona.nombrePersona = request.nombrePersona; }
            if (request.fechaNacPersona != DateTime.MinValue) { persona.fechaNacPersona = request.fechaNacPersona; }
            if (request.mailPersona != null) {
                if (!IsValidEmail(request.mailPersona))
                {
                    return null;
                }
                persona.mailPersona = request.mailPersona; 
            }
            if (request.direccionPersona != null) { persona.direccionPersona = request.direccionPersona; }
            if (request.userPersona != null) { persona.userPersona = request.userPersona; }
            if (request.celularPersona != null) { persona.celularPersona = request.celularPersona; }

            db.Persona.Update(persona);
            persona.Update();
            await db.SaveChangesAsync();

            return persona;
        }

        private bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }


        protected internal void EnviarMail(Persona persona, string contenido, string encabezado)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Gamma", "rafafabiani1909@gmail.com"));
            message.To.Add(new MailboxAddress("Cliente", persona.codPersona));
            message.Subject = encabezado;
            message.Body = new TextPart("plain")
            {
                Text = contenido,
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("rafafabiani1909@gmail.com", "bciuwmlnedihsfga");

                client.Send(message);
                client.Disconnect(true);
            }
            return;
        }
    }
}
