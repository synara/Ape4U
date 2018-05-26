namespace RedeSocialCondominio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCampoAssunto_tblNotificacao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notificacoes", "Assunto", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notificacoes", "Assunto");
        }
    }
}
