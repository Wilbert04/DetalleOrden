using DetalleOrden.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DetalleOrden.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Orden> ordenTable { get; set; }
        public DbSet<Producto> productoTable { get; set; }
        public DbSet<Cliente> clienteTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@" DataSource = Detalle1.db");
        }
    }
}
