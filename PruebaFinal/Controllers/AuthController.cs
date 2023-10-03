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

        public PruebaFinalContext db;
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
        public string Login(string userPersona, string passwordPersona)
        {
            string hPassword = Crypto.HashPassword(passwordPersona);
            string hUser = Crypto.HashPassword(userPersona);

            var persona = db.Persona.Single(b => b.userPersona == hUser);

            if(persona != null)
            {
                if(persona.passwordPersona == hPassword)
                {
                    return "sis";
                }
                else
                {
                    return "non, pass";
                }
            }
            else
            {
                return "non, null";
            }
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
