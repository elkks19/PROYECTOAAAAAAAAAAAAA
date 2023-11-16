using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Models;

namespace API.Controllers
{
    public class GuardadoCarritoController : Controller
    {
        private readonly APIContext db;

        public GuardadoCarritoController(APIContext context)
        {
            db = context;
        }
    }
}
