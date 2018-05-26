namespace RedeSocialCondominio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTblReuniao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reunioes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Assunto = c.String(),
                        Descricao = c.String(),
                        HoraInicio = c.DateTime(nullable: false),
                        HoraFim = c.DateTime(nullable: false),
                        Dia = c.DateTime(nullable: false),
                        UsuarioId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Reunioes");
        }
    }
}
