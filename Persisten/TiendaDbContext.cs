using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persisten
{
    public class TiendaDbContext : DbContext
    {
        public DbSet<Accesorios> accesorios { get; set; }
        public DbSet<Cliente> clientes { get; set; }

        public TiendaDbContext(DbContextOptions<TiendaDbContext> options)
        : base(options)
        { }
    }
}
