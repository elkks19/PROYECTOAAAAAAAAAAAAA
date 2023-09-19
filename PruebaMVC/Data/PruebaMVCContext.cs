using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaMVC.Models;

namespace PruebaMVC.Data
{
    public class PruebaMVCContext : DbContext
    {
        public PruebaMVCContext (DbContextOptions<PruebaMVCContext> options)
            : base(options)
        {
        }

        public DbSet<PruebaMVC.Models.Usuarios> Usuarios { get; set; } = default!;
    }
}
