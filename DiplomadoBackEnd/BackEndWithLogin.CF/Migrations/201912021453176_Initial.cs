namespace BackEndWithLogin.CF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Municipio",
                c => new
                    {
                        IDMunicipio = c.Int(nullable: false, identity: true),
                        IDProvincia = c.Int(nullable: false),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.IDMunicipio);
            
            CreateTable(
                "dbo.Participante",
                c => new
                    {
                        IDParticipante = c.Int(nullable: false, identity: true),
                        Cedula = c.String(nullable: false, maxLength: 11),
                        Nombre = c.String(nullable: false, maxLength: 25),
                        Apellidos = c.String(nullable: false, maxLength: 30),
                        FechaNacimiento = c.DateTime(nullable: false),
                        IDCiudad = c.Int(nullable: false),
                        Telefono = c.String(),
                        Celular = c.String(),
                        Email = c.String(nullable: false),
                        URLImage = c.String(),
                        Sexo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IDParticipante);
            
            CreateTable(
                "dbo.Provincia",
                c => new
                    {
                        IDProvincia = c.Int(nullable: false, identity: true),
                        Nombre = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDProvincia);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Provincia");
            DropTable("dbo.Participante");
            DropTable("dbo.Municipio");
        }
    }
}
