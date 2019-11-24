namespace BackEnd.CF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changefield1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Productos", "Disponible", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Productos", "Disponible", c => c.Single(nullable: false));
        }
    }
}
