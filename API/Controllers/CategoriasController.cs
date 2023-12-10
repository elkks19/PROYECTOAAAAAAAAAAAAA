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
        [Autorizado("administrador")]
        public async Task<IActionResult> Index()
        {
            var categorias = await db.Categorias.Select(x => new
            {
                x.codCategoria,
                x.nombreCategoria,
                x.activo
            }).Where(x => x.activo.Equals(true)).ToListAsync();

            return Ok(categorias);
        }

        [HttpPost]
        [Autorizado("administrador")]
        public async Task<IActionResult> Create([FromBody]Categoria request)
        {
            var categoriaExists = await db.Categorias.FirstOrDefaultAsync(x => x.nombreCategoria.Equals(request.nombreCategoria));
            if (categoriaExists != null)
            {
                categoriaExists.Activar();
            }
            else
            {
                var cantCategorias = await db.Categorias.CountAsync() + 1;

                var categoriaNueva = new Categoria()
                {
                    codCategoria = "CAT-" + cantCategorias.ToString("000"),
                    nombreCategoria = request.nombreCategoria
                };
                await db.Categorias.AddAsync(categoriaNueva);
            }

            await db.SaveChangesAsync();
            return Ok("La categoria se guardo correctamente");
        }

        [HttpPatch]
        [Autorizado("administrador")]
        public async Task<IActionResult> Edit([FromBody]Categoria request, [FromRoute]string cod)
        {
            var categoria = await db.Categorias.FirstOrDefaultAsync(x => x.codCategoria.Equals(cod));
            if (categoria == null)
            {
                return BadRequest("No se encontro la categoria");
            }

            var categoriaExists = await db.Categorias.FirstOrDefaultAsync(x => x.nombreCategoria.Equals(request.nombreCategoria));
            if (categoriaExists != null)
            {
                categoriaExists.Activar();
            }
            else
            {
            
                if (request.nombreCategoria != null) { categoria.nombreCategoria = request.nombreCategoria; }
                db.Categorias.Update(categoria);
            }

            await db.SaveChangesAsync();
            return Ok("Categoria añadida correctamente");
        }

        [HttpGet]
        [Autorizado("administrador")]
        public async Task<IActionResult> Details([FromRoute]string cod)
        {
            var categoria = await db.Categorias.FirstOrDefaultAsync(x => x.codCategoria.Equals(cod));

            if (categoria == null)
            {
                return BadRequest("No se encontro la categoria");
            }

            return Ok(categoria);
        }

        [HttpDelete]
        [Autorizado("administrador")]
        public async Task<IActionResult> Delete([FromRoute]string cod)
        {
            var categoria = await db.Categorias.FirstOrDefaultAsync(x => x.codCategoria.Equals(cod));

            if (categoria == null)
            {
                return BadRequest("No se encontro la categoria");
            }

            categoria.Desactivar();
            await db.SaveChangesAsync();

            return Ok("La categoria se elimino correctamente");
        }
    }
}
