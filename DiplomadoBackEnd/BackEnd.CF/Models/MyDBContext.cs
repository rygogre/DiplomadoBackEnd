using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace BackEnd.CF.Models
{
    public class MyDBContext : DbContext
    {
        public MyDBContext()
            :base("MiConexion")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Limita que EntityFramework coloque nombres en plural.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}