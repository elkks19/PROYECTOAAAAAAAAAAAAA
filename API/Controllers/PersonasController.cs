using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Web.Helpers;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;
using System.Globalization;

namespace API.Controllers
{
    [EnableCors]
    public class PersonasController : Controller
    {
        private readonly APIContext db;

        public PersonasController(APIContext context)
        {
            db = context;
        }
    }
}
