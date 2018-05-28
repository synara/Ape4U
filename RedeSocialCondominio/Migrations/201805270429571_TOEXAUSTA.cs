namespace RedeSocialCondominio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TOEXAUSTA : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NotificacaoMudancas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MudancaId = c.Int(nullable: false),
                        NotificacaoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Mudancas", t => t.MudancaId, cascadeDelete: true)
                .ForeignKey("dbo.Notificacoes", t => t.NotificacaoId, cascadeDelete: true)
                .Index(t => t.MudancaId)
                .Index(t => t.NotificacaoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NotificacaoMudancas", "NotificacaoId", "dbo.Notificacoes");
            DropForeignKey("dbo.NotificacaoMudancas", "MudancaId", "dbo.Mudancas");
            DropIndex("dbo.NotificacaoMudancas", new[] { "NotificacaoId" });
            DropIndex("dbo.NotificacaoMudancas", new[] { "MudancaId" });
            DropTable("dbo.NotificacaoMudancas");
        }
    }
}
