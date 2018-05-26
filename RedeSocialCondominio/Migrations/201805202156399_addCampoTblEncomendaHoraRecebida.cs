namespace RedeSocialCondominio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCampoTblEncomendaHoraRecebida : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Encomendas", "HoraRecebida", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Encomendas", "HoraRecebida");
        }
    }
}
