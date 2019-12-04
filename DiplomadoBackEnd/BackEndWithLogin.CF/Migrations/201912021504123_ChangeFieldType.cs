namespace BackEndWithLogin.CF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFieldType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Provincia", "Nombre", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Provincia", "Nombre", c => c.Int(nullable: false));
        }
    }
}
