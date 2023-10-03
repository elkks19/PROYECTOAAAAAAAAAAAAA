using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaFinal.Models;
using PruebaFinal.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel;
using System.Web.Helpers;

namespace PruebaFinal.Controllers
{
    public class AuthController : Controller
    {
        private readonly PruebaFinalContext db;
        public AuthController(PruebaFinalContext db)
        {
            this.db = db;
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
                userPersona = Crypto.HashPassword(model.userPersona),
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
        public IActionResult Login(string user, string password)
        {
            var hPassword = Crypto.HashPassword(password);
            var hUser = Crypto.HashPassword(user);

            var persona = db.Persona.FirstOrDefault(p => p.userPersona == hUser);

            bool userExists = Crypto.VerifyHashedPassword(hPassword, persona.passwordPersona);
            
            if(userExists)
            {
                return View("Index");
            }
            return View("Index");
        }



        // GET: AuthController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AuthController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AuthController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AuthController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
