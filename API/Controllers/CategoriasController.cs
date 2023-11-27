using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;
using API.Atributos;

namespace API.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly APIContext db;

        public CategoriasController(APIContext context)
        {
            db = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categorias = await db.Categorias.ToListAsync();
            return Ok(categorias);
        }

        [HttpPost]
        public async Task<IActionResult> Upsert([FromBody]string nombreCategoria)
        {
            var cantCategorias = await db.Categorias.CountAsync();
            var categoria = new Categoria()
            {
                codCategoria = "CAT-" + cantCategorias.ToString("000"),
                nombreCategoria = nombreCategoria
            };

            await db.Categorias.AddAsync(categoria);
            await db.SaveChangesAsync();

            return Ok("Categoria añadida correctamente");
        }
    }
}
