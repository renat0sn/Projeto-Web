﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VendasWeb.Models;

namespace VendasWeb.Data
{
    public class VendasWebContext : DbContext
    {
        public VendasWebContext (DbContextOptions<VendasWebContext> options)
            : base(options)
        {
        }

        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<RegistroDeVendas> RegistroDeVendas { get; set; }
        public DbSet <Vendedor> Vendedor { get; set; }
    }
}
