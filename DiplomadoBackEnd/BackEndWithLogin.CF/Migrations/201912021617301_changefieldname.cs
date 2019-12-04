namespace BackEndWithLogin.CF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changefieldname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Participante", "IDMunicipio", c => c.Int(nullable: false));
            DropColumn("dbo.Participante", "IDCiudad");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Participante", "IDCiudad", c => c.Int(nullable: false));
            DropColumn("dbo.Participante", "IDMunicipio");
        }
    }
}
