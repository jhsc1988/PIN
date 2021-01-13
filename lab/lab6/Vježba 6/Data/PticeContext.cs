using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vježba_6.Models;

namespace Vježba_6.Data
{
    public class PticeContext : DbContext
    {
        public PticeContext (DbContextOptions<PticeContext> options)
            : base(options)
        {
        }

        public DbSet<Vježba_6.Models.Ptice> Ptice { get; set; }
    }
}
