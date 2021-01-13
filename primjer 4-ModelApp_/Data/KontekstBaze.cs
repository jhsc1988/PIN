﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using primjer_4_ModelApp.Models;

namespace primjer_4_ModelApp.Data
{
    public class KontekstBaze : DbContext
    {
        public KontekstBaze (DbContextOptions<KontekstBaze> options)
            : base(options)
        {
        }

        public DbSet<primjer_4_ModelApp.Models.Ljubimac> Ljubimac { get; set; }

        public DbSet<primjer_4_ModelApp.Models.Vrsta> Vrsta { get; set; }
    }
}
