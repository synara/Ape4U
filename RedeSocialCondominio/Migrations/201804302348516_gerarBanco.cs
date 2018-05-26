namespace RedeSocialCondominio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gerarBanco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Encomendas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeEncomenda = c.String(),
                        NomeResponsavel = c.String(),
                        UsuarioId = c.String(),
                        NomeQuemRecebeu = c.String(),
                        DataHoraEntrega = c.DateTime(nullable: false),
                        DescricaoEncomenda = c.String(),
                        Fragil = c.Boolean(nullable: false),
                        Usuario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_Id)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        PerfilId = c.Int(),
                        UsuarioId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Perfis", t => t.PerfilId)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioId)
                .Index(t => t.PerfilId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Perfis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Hometown = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.UsuarioNotificacoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NotificacaoId = c.Int(nullable: false),
                        IsLido = c.Boolean(nullable: false),
                        UsuarioId = c.String(),
                        Data = c.DateTime(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Funcionalidades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Controller = c.String(),
                        Action = c.String(),
                        PerfilId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Perfis", t => t.PerfilId)
                .Index(t => t.PerfilId);
            
            CreateTable(
                "dbo.Horarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeVisitante = c.String(),
                        Dia = c.DateTime(nullable: false),
                        Hora = c.DateTime(nullable: false),
                        UsuarioId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HorariosLocais",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HorarioInicial = c.DateTime(nullable: false),
                        HorarioFinal = c.DateTime(nullable: false),
                        LocalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locais", t => t.LocalId, cascadeDelete: true)
                .Index(t => t.LocalId);
            
            CreateTable(
                "dbo.Locais",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Mudancas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Data = c.DateTime(nullable: false),
                        Hora = c.DateTime(nullable: false),
                        TipoMudancaId = c.Int(nullable: false),
                        Comentario = c.String(),
                        UsuarioId = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TiposMudanca", t => t.TipoMudancaId, cascadeDelete: true)
                .Index(t => t.TipoMudancaId);
            
            CreateTable(
                "dbo.TiposMudanca",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NotificacaoOcorrencias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OcorrenciaId = c.Int(nullable: false),
                        NotificacaoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Notificacoes", t => t.NotificacaoId, cascadeDelete: true)
                .ForeignKey("dbo.Ocorrencias", t => t.OcorrenciaId, cascadeDelete: true)
                .Index(t => t.OcorrenciaId)
                .Index(t => t.NotificacaoId);
            
            CreateTable(
                "dbo.Notificacoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Dia = c.DateTime(),
                        HoraInicial = c.DateTime(),
                        HoraFinal = c.DateTime(),
                        HoraEmQueOcorreu = c.DateTime(),
                        Espaco = c.String(),
                        PerfilUsuarioPermitidoAReceber = c.Int(),
                        UsuarioId = c.String(),
                        TipoNotificacaoId = c.Int(nullable: false),
                        TipoNotificacao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ocorrencias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Assunto = c.String(),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NotificacaoReservas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReservaId = c.Int(nullable: false),
                        NotificacaoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Notificacoes", t => t.NotificacaoId, cascadeDelete: true)
                .ForeignKey("dbo.Reservas", t => t.ReservaId, cascadeDelete: true)
                .Index(t => t.ReservaId)
                .Index(t => t.NotificacaoId);
            
            CreateTable(
                "dbo.Reservas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                        HoraInicio = c.DateTime(nullable: false),
                        HoraFim = c.DateTime(nullable: false),
                        LocalId = c.Int(),
                        HoraExtraInicial = c.DateTime(),
                        HoraExtraFinal = c.DateTime(),
                        IsDiaTodo = c.Boolean(nullable: false),
                        UserId = c.String(),
                        CorReserva = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locais", t => t.LocalId)
                .Index(t => t.LocalId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Visitantes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        UsuarioId = c.String(),
                        DiaVisita = c.DateTime(nullable: false),
                        HoraVisita = c.DateTime(nullable: false),
                        Comentario = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.NotificacaoReservas", "ReservaId", "dbo.Reservas");
            DropForeignKey("dbo.Reservas", "LocalId", "dbo.Locais");
            DropForeignKey("dbo.NotificacaoReservas", "NotificacaoId", "dbo.Notificacoes");
            DropForeignKey("dbo.NotificacaoOcorrencias", "OcorrenciaId", "dbo.Ocorrencias");
            DropForeignKey("dbo.NotificacaoOcorrencias", "NotificacaoId", "dbo.Notificacoes");
            DropForeignKey("dbo.Mudancas", "TipoMudancaId", "dbo.TiposMudanca");
            DropForeignKey("dbo.HorariosLocais", "LocalId", "dbo.Locais");
            DropForeignKey("dbo.Funcionalidades", "PerfilId", "dbo.Perfis");
            DropForeignKey("dbo.Encomendas", "Usuario_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Usuarios", "UsuarioId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UsuarioNotificacoes", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Usuarios", "PerfilId", "dbo.Perfis");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Reservas", new[] { "LocalId" });
            DropIndex("dbo.NotificacaoReservas", new[] { "NotificacaoId" });
            DropIndex("dbo.NotificacaoReservas", new[] { "ReservaId" });
            DropIndex("dbo.NotificacaoOcorrencias", new[] { "NotificacaoId" });
            DropIndex("dbo.NotificacaoOcorrencias", new[] { "OcorrenciaId" });
            DropIndex("dbo.Mudancas", new[] { "TipoMudancaId" });
            DropIndex("dbo.HorariosLocais", new[] { "LocalId" });
            DropIndex("dbo.Funcionalidades", new[] { "PerfilId" });
            DropIndex("dbo.UsuarioNotificacoes", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Usuarios", new[] { "UsuarioId" });
            DropIndex("dbo.Usuarios", new[] { "PerfilId" });
            DropIndex("dbo.Encomendas", new[] { "Usuario_Id" });
            DropTable("dbo.Visitantes");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Reservas");
            DropTable("dbo.NotificacaoReservas");
            DropTable("dbo.Ocorrencias");
            DropTable("dbo.Notificacoes");
            DropTable("dbo.NotificacaoOcorrencias");
            DropTable("dbo.TiposMudanca");
            DropTable("dbo.Mudancas");
            DropTable("dbo.Locais");
            DropTable("dbo.HorariosLocais");
            DropTable("dbo.Horarios");
            DropTable("dbo.Funcionalidades");
            DropTable("dbo.UsuarioNotificacoes");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Perfis");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Encomendas");
        }
    }
}
