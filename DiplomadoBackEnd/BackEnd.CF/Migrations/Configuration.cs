namespace BackEnd.CF.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BackEnd.CF.Models.MyDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BackEnd.CF.Models.MyDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Productos.AddOrUpdate(
                d => d.Descripcion,
                new Models.Producto { Descripcion = "Alimentos", 
                                    Costo = 10, CategoriaID=1,
                                    FechaVencimiento=DateTime.Now.AddMonths(5),
                                    Estatus = true, Precio=15},

                new Models.Producto
                {
                    Descripcion = "Refresco",
                    Costo = 22,
                    CategoriaID = 1,
                    FechaVencimiento = DateTime.Now.AddMonths(6),
                    Estatus = true,
                    Precio = 24
                }

                );
        }
    }
}
