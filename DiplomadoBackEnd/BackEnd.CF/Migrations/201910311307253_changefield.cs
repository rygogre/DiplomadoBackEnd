namespace BackEnd.CF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changefield : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productoes", "Estatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Productoes", "Estatus");
        }
    }
}
