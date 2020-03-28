using System;
using System.Collections.Generic;
using System.Text;
using StudioEA.Entidades;
using Microsoft.EntityFrameworkCore;

namespace StudioEA.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Fotografos> Fotografos { get; set; }
        public DbSet<Articulos> Articulos { get; set; }
        public DbSet<Eventos> Eventos { get; set; }
        public DbSet<Categorias> Categorias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data source= StudioEA.db");
        }
    }
}
