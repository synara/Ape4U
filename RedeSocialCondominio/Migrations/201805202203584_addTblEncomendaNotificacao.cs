namespace RedeSocialCondominio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTblEncomendaNotificacao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NotificacaoEncomendas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NotificacaoId = c.Int(nullable: false),
                        EncomendaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Encomendas", t => t.EncomendaId, cascadeDelete: true)
                .ForeignKey("dbo.Notificacoes", t => t.NotificacaoId, cascadeDelete: true)
                .Index(t => t.NotificacaoId)
                .Index(t => t.EncomendaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NotificacaoEncomendas", "NotificacaoId", "dbo.Notificacoes");
            DropForeignKey("dbo.NotificacaoEncomendas", "EncomendaId", "dbo.Encomendas");
            DropIndex("dbo.NotificacaoEncomendas", new[] { "EncomendaId" });
            DropIndex("dbo.NotificacaoEncomendas", new[] { "NotificacaoId" });
            DropTable("dbo.NotificacaoEncomendas");
        }
    }
}
