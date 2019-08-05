using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public class TiendaDbContext: DbContext
    {
       

        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Consola> consolas { get; set; }
        public DbSet<Accesorios> accesorios { get; set; }
        public DbSet<Games> games { get; set; }
        public DbSet<Compra_Accesorio> compra_Accesorios { get; set; }
        public DbSet<Compra_Consola> compra_Consolas { get; set; }
        public DbSet<Compra_Game> compra_Games { get; set; }
       

        public TiendaDbContext(DbContextOptions<TiendaDbContext> options)
            :base(options)
        { }
    }
}
