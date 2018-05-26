namespace RedeSocialCondominio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class permitirNuloCampotblEncomendaHoraRecebida : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Encomendas", "HoraRecebida", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Encomendas", "HoraRecebida", c => c.DateTime(nullable: false));
        }
    }
}
