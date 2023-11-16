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

        public async Task<IActionResult> Index()
        {
            var categorias = db.Categorias.ToList();
            return Ok(categorias);
        }

        public async Task<IActionResult> Create([FromBody]string nombreCategoria)
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
