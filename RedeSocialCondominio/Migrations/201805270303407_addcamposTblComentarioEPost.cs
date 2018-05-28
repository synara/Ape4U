namespace RedeSocialCondominio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcamposTblComentarioEPost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comentarios", "UsuarioId", c => c.String());
            AddColumn("dbo.Comentarios", "NomeUsuarioQuePostou", c => c.String());
            AddColumn("dbo.Posts", "UsuarioId", c => c.String());
            AddColumn("dbo.Posts", "NomeUsuarioQuePostou", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "NomeUsuarioQuePostou");
            DropColumn("dbo.Posts", "UsuarioId");
            DropColumn("dbo.Comentarios", "NomeUsuarioQuePostou");
            DropColumn("dbo.Comentarios", "UsuarioId");
        }
    }
}
