namespace RedeSocialCondominio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTblNotificacaoReuniao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NotificacaoReuniaos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NotificacaoId = c.Int(nullable: false),
                        ReuniaoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Notificacoes", t => t.NotificacaoId, cascadeDelete: true)
                .ForeignKey("dbo.Reunioes", t => t.ReuniaoId, cascadeDelete: true)
                .Index(t => t.NotificacaoId)
                .Index(t => t.ReuniaoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NotificacaoReuniaos", "ReuniaoId", "dbo.Reunioes");
            DropForeignKey("dbo.NotificacaoReuniaos", "NotificacaoId", "dbo.Notificacoes");
            DropIndex("dbo.NotificacaoReuniaos", new[] { "ReuniaoId" });
            DropIndex("dbo.NotificacaoReuniaos", new[] { "NotificacaoId" });
            DropTable("dbo.NotificacaoReuniaos");
        }
    }
}
