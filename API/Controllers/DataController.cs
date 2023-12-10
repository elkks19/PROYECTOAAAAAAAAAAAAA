using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Web.Helpers;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class DataController : Controller
    {
        public readonly APIContext db;
        public readonly IWebHostEnvironment env;
        public readonly ListaEsperaController listaC;
        public DataController(APIContext context, IWebHostEnvironment environment, ListaEsperaController listaEsperaController)
        {
            db = context;
            env = environment;
            listaC = listaEsperaController;
        }

        [HttpGet]
        public async Task<IActionResult> Seed()
        {
            //PERSONAS
            StreamReader rPersonas = new StreamReader(env.ContentRootPath + "/datos/personas.json");
            string jsonPersonas = rPersonas.ReadToEnd();

            List<Persona> personas = JsonConvert.DeserializeObject<List<Persona>>(jsonPersonas, new IsoDateTimeConverter() { DateTimeFormat = "dd/MM/yyyy" });

            foreach (var persona in personas)
            {
                persona.pathFotoPersona = env.ContentRootPath + "/Imagenes/perrito.jpg";
                persona.passwordPersona = Crypto.HashPassword(persona.passwordPersona);
                await db.Persona.AddAsync(persona);
            }


            //ADMINISTRADORES
            StreamReader rAdmins = new StreamReader(env.ContentRootPath + "/datos/administradores.json");
            string jsonAdmins = rAdmins.ReadToEnd();

            List<Administrador> admins = JsonConvert.DeserializeObject<List<Administrador>>(jsonAdmins, new IsoDateTimeConverter() { DateTimeFormat = "dd/MM/yyyy" });

            foreach (var admin in admins)
            {
                await db.Administradores.AddAsync(admin);
            }


            //CATEGORIAS
            StreamReader rCat = new StreamReader(env.ContentRootPath + "/datos/Categorias.json");
            string jsonCats = rCat.ReadToEnd();

            List<Categoria> cats = JsonConvert.DeserializeObject<List<Categoria>>(jsonCats, new IsoDateTimeConverter() { DateTimeFormat = "dd/MM/yyyy" });

            foreach (var cat in cats)
            {
                await db.Categorias.AddAsync(cat);
            }

            //EMPRESAS
            StreamReader rEmpresa = new StreamReader(env.ContentRootPath + "/datos/empresa.json");
            string jsonEmpresas = rEmpresa.ReadToEnd();

            List<Empresa> empresas = JsonConvert.DeserializeObject<List<Empresa>>(jsonEmpresas, new IsoDateTimeConverter() { DateTimeFormat = "dd/MM/yyyy" });

            foreach (var empresa in empresas)
            {
                Random rnd = new Random();
                int randomAdmin = rnd.Next(admins.Count);
                if (admins.Count == 0)
                {
                    return BadRequest("No se reconocen los admins xd");
                }

                ListaEsperaEmpresa listaEspera = new ListaEsperaEmpresa()
                {
                    Empresa = empresa,
                    codAdmin = admins[randomAdmin].codAdmin
                };
                await db.ListaEsperaEmpresa.AddAsync(listaEspera);

                empresa.archivoVerificacionEmpresa = env.ContentRootPath + "/ArchivosVerificacion/rafa/1.png";
                await db.Empresa.AddAsync(empresa);
            }

            //USUARIOS
            StreamReader rUsuarios = new StreamReader(env.ContentRootPath + "/datos/usuario.json");
            string jsonUsuarios = rUsuarios.ReadToEnd();

            List<Usuario> usuarios = JsonConvert.DeserializeObject<List<Usuario>>(jsonUsuarios, new IsoDateTimeConverter() { DateTimeFormat = "dd/MM/yyyy" });

            foreach (var usuario in usuarios)
            {
                await db.Usuarios.AddAsync(usuario);
            }

            //PERSONAL EMPRESA
            StreamReader rPersonal = new StreamReader(env.ContentRootPath + "/datos/personalempresa.json");
            string jsonPersonal = rPersonal.ReadToEnd();

            List<PersonalEmpresa> personales = JsonConvert.DeserializeObject<List<PersonalEmpresa>>(jsonPersonal, new IsoDateTimeConverter() { DateTimeFormat = "dd/MM/yyyy" });

            foreach (var personal in personales)
            {
                await db.PersonalEmpresa.AddAsync(personal);
            }


            //ORDENES
            StreamReader rOrdenes = new StreamReader(env.ContentRootPath + "/datos/Orrden.json");
            string jsonOrdenes = rOrdenes.ReadToEnd();

            List<Orden> ordenes = JsonConvert.DeserializeObject<List<Orden>>(jsonOrdenes, new IsoDateTimeConverter() { DateTimeFormat = "dd/MM/yyyy" });

            foreach (var orden in ordenes)
            {
                orden.fechaEntregaOrden = DateTime.Now;
                await db.Orden.AddAsync(orden);
            }


            //DETALLES ORDEN
            StreamReader rDetOrden = new StreamReader(env.ContentRootPath + "/datos/DetalleOorden.json");
            string jsonDetO = rDetOrden.ReadToEnd();

            List<DetalleOrden> detallesOrden = JsonConvert.DeserializeObject<List<DetalleOrden>>(jsonDetO, new IsoDateTimeConverter() { DateTimeFormat = "dd/MM/yyyy" });

            foreach (var detOrden in detallesOrden)
            {
                await db.DetalleOrden.AddAsync(detOrden);
            }

            //PRODUCTOS
            StreamReader rProductos = new StreamReader(env.ContentRootPath + "/datos/productos.json");
            string jsonProductos = rProductos.ReadToEnd();

            List<Producto> productos = JsonConvert.DeserializeObject<List<Producto>>(jsonProductos, new IsoDateTimeConverter() { DateTimeFormat = "dd/MM/yyyy" });

            foreach (var producto in productos)
            {
                producto.pathFotoProducto = env.ContentRootPath + "/ImagenesProductos/" + producto.pathFotoProducto;
                await db.Producto.AddAsync(producto);
            }

            //CATEGORIAS POR PRODUCTO
            StreamReader rCatsProds = new StreamReader(env.ContentRootPath + "/datos/categoriaporproducto.json");
            string jsonCaPro = rCatsProds.ReadToEnd();

            List<CategoriasPorProducto> cpp = JsonConvert.DeserializeObject<List<CategoriasPorProducto>>(jsonCaPro);

            foreach (var catpro in cpp)
            {
                await db.CategoriasPorProducto.AddAsync(catpro);
            }

            //RECLAMOS
            StreamReader rReclamos = new StreamReader(env.ContentRootPath + "/datos/reclamosempresa.json");
            string jsonReclamos = rReclamos.ReadToEnd();

            List<ReclamosEmpresa> reclamos = JsonConvert.DeserializeObject<List<ReclamosEmpresa>>(jsonReclamos);

            foreach (var reclamo in reclamos)
            {
                await db.ReclamosEmpresa.AddAsync(reclamo);
            }

            await db.SaveChangesAsync();
            return Ok();
        }
    }
}
