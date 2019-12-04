namespace BackEndFinal.CF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initia : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Participante",
                c => new
                    {
                        IDParticipante = c.Int(nullable: false, identity: true),
                        Cedula = c.String(nullable: false, maxLength: 11),
                        Nombre = c.String(nullable: false, maxLength: 25),
                        Apellidos = c.String(nullable: false, maxLength: 30),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Ciudad = c.Int(nullable: false),
                        Telefono = c.String(),
                        Celular = c.String(),
                        Email = c.String(),
                        URLImage = c.String(),
                        Sexo = c.String(),
                    })
                .PrimaryKey(t => t.IDParticipante);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Participante");
        }
    }
}
