namespace BackEnd.CF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class camposrequeridos : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Productoes", "Descripcion", c => c.String(nullable: false, maxLength: 80));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Productoes", "Descripcion", c => c.String(nullable: false));
        }
    }
}
