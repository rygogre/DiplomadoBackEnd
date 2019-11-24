namespace BackEnd.CF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IDCateogria : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Categorias", newName: "Categoria");
            RenameTable(name: "dbo.Productoes", newName: "Productos");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Productos", newName: "Productoes");
            RenameTable(name: "dbo.Categoria", newName: "Categorias");
        }
    }
}
