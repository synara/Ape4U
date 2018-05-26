namespace RedeSocialCondominio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class consertandoCampoIsLido_tblUsuarioNotificacao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UsuarioNotificacoes", "Usuario_Id", c => c.Int());
            CreateIndex("dbo.UsuarioNotificacoes", "NotificacaoId");
            CreateIndex("dbo.UsuarioNotificacoes", "Usuario_Id");
            AddForeignKey("dbo.UsuarioNotificacoes", "NotificacaoId", "dbo.Notificacoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UsuarioNotificacoes", "Usuario_Id", "dbo.Usuarios", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsuarioNotificacoes", "Usuario_Id", "dbo.Usuarios");
            DropForeignKey("dbo.UsuarioNotificacoes", "NotificacaoId", "dbo.Notificacoes");
            DropIndex("dbo.UsuarioNotificacoes", new[] { "Usuario_Id" });
            DropIndex("dbo.UsuarioNotificacoes", new[] { "NotificacaoId" });
            DropColumn("dbo.UsuarioNotificacoes", "Usuario_Id");
        }
    }
}
