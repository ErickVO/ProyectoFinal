using Microsoft.EntityFrameworkCore;
using StudioEA.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudioEA.DAL
{
   public class Contexto : DbContext
    {
        public DbSet<Articulos> Articulos { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Eventos> Eventos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = DAL\StudioEA.db");
        }
    }
}
