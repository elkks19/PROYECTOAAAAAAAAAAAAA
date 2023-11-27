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
            var categorias = await db.Categorias.Select(x => new
            {
                x.codCategoria,
                x.nombreCategoria
            }).ToListAsync();
            return Ok(categorias);
        }

        [HttpPost]
        public async Task<IActionResult> Upsert([FromBody]string nombreCategoria)
        {
            var categoriaExiste = await db.Categorias.FirstOrDefaultAsync(x => x.nombreCategoria.Equals(nombreCategoria));
            if (categoriaExiste == null)
            {
                var cantCategorias = await db.Categorias.CountAsync();
                var categoria = new Categoria()
                {
                    codCategoria = "CAT-" + cantCategorias.ToString("000"),
                    nombreCategoria = nombreCategoria
                };
                await db.Categorias.AddAsync(categoria);
            }

            categoriaExiste.nombreCategoria = nombreCategoria;
            db.Categorias.Update(categoriaExiste);
            await db.SaveChangesAsync();

            return Ok("Categoria añadida correctamente");
        }

        [HttpGet]
        public async Task<IActionResult> Details([FromRoute]string cod)
        {
            var categoria = db.Categorias.FirstOrDefaultAsync(x => x.codCategoria.Equals(cod));

            if (categoria == null)
            {
                return BadRequest("No se encontro la categoria");
            }

            return Ok(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute]string cod)
        {
            var categoria = await db.Categorias.FirstOrDefaultAsync(x => x.codCategoria.Equals(cod));

            if (categoria == null)
            {
                return BadRequest("No se encontro la categoria");
            }

            db.Categorias.Remove(categoria);

            return Ok("La categoria se elimino correctamente");
        }
    }
}
