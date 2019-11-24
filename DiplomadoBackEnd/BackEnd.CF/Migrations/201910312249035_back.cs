namespace BackEnd.CF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class back : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Productos", "Descripcion", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Productos", "Descripcion", c => c.String(nullable: false, maxLength: 80));
        }
    }
}
