namespace BackEndWithLogin.CF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class confirmaremail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Participante", "ConfirmarEmail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Participante", "ConfirmarEmail");
        }
    }
}
