using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;

namespace API.Controllers
{
    public class Detalle_WishlistController : Controller
    {
        private readonly APIContext db;

        public Detalle_WishlistController(APIContext context)
        {
            db = context;
        }
    }
}
