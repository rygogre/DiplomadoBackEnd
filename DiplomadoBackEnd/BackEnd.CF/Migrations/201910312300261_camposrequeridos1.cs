namespace BackEnd.CF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class camposrequeridos1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Productos", newName: "Productoes");
            AlterColumn("dbo.Productoes", "Descripcion", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Productoes", "Descripcion", c => c.String());
            RenameTable(name: "dbo.Productoes", newName: "Productos");
        }
    }
}
