using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace API.Controllers
{
    public class DataController : Controller
    {
        public readonly APIContext db;
        public readonly IWebHostEnvironment env;
        public DataController(APIContext context, IWebHostEnvironment environment)
        {
            db = context;
            env = environment;
        }
          
        [HttpGet]
        public async Task<IActionResult> Data()
        {
            //PERSONAS
            StreamReader rPersonas = new StreamReader(env.ContentRootPath + "/datos/personas.json");
            string jsonPersonas = rPersonas.ReadToEnd();

            List<Persona> personas = JsonConvert.DeserializeObject<List<Persona>>(jsonPersonas, new IsoDateTimeConverter() { DateTimeFormat = "d/M/yyyy" });

            foreach(var persona in personas)
            {
                await db.Persona.AddAsync(persona);
            }


            //ADMINISTRADORES
            StreamReader rAdmins = new StreamReader(env.ContentRootPath + "/datos/administradores.json");
            string jsonAdmins = rAdmins.ReadToEnd();

            List<Administrador> admins = JsonConvert.DeserializeObject<List<Administrador>>(jsonAdmins);

            foreach(var admin in admins)
            {
                await db.Administradores.AddAsync(admin);
            }


            //CATEGORIAS
            StreamReader rCat = new StreamReader(env.ContentRootPath + "/datos/Categorias.json");
            string jsonCats = rCat.ReadToEnd();

            List<Categoria> Cats = JsonConvert.DeserializeObject<List<Categoria>>(jsonAdmins);

            foreach(var admin in admins)
            {
                await db.Administradores.AddAsync(admin);
            }
            return Ok();
        }
    }
}
