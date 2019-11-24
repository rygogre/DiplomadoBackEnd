namespace BackEnd.CF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addfield : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productos", "Disponible", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Productos", "Disponible");
        }
    }
}
