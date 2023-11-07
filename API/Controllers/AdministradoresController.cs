using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AdministradoresController : Controller
    {
        private readonly APIContext db;

        public AdministradoresController(APIContext context)
        {
            db = context;
        }
        //public async Task<IActionResult> RevisionesPendientes([FromRoute]string cod)
        //{
        //    var listaEspera = db.Administradores.Include(x => x.Lista_Espera_Empresas).ToList().Where(x => x.codAdmin.Equals(cod));
        //    foreach(var item in listaEspera)
        //    {
        //    }
        //}
        //public async Task<IActionResult> Create(Administrador request)
        //{

        //}
    }
}
