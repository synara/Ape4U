namespace RedeSocialCondominio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCampoTblEncomenda : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Encomendas", "Entregue", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Encomendas", "Entregue");
        }
    }
}
